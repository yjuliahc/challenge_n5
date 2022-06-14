using AutoMapper;
using Challenge_n5.Infrastructure;
using Challenge_n5.Models;
using Challenge_n5.Views;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Challenge_n5.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PermisosController:ControllerBase
    {
        private readonly IUnitOfWork unit;
        private readonly IMapper mapper;
        private readonly ILogger<PermisosController> logger;

        public PermisosController(IUnitOfWork unit, IMapper mapper, ILogger<PermisosController> logger)
        {
            this.unit = unit;
            this.mapper = mapper;
            this.logger = logger;            
        }

        [HttpGet("obtenerpermisos")]
        public async Task<ActionResult<IEnumerable<PermisoConsultaDTO>>> Get()
        {
            var permisos = await unit.PermisoRepo.GetWithPermissionAsync();
            logger.LogInformation("Obteniendo la lista de los permisos");
            return mapper.Map<List<PermisoConsultaDTO>>(permisos);
        }

        [HttpPut("modificarpermiso/{id:int}")]
        public async Task<ActionResult> Put(PermisoDTO permisoDTO,int id) {

            if (permisoDTO.Id != id)
            {
                logger.LogWarning("El id del permiso no coincide con el id de la url");
                return BadRequest("El id del permiso no coincide con el id de la url");
            }

            bool existsId = await unit.TipoPermisoRepo.existsAsync(permisoDTO.TipoPermisoId);

            if (!existsId)
            {
                logger.LogWarning("Tipo de permiso incorrecto");
                return BadRequest("Tipo permiso incorrecto");
            }

            bool different = await unit.PermisoRepo.different(permisoDTO);
            if (different)
            {
                logger.LogWarning("Ya existe un usuario con los mismos datos");
                return BadRequest("Ya existe un usuario con los mismos datos");
            }

            var permiso = mapper.Map<Permiso>(permisoDTO);            
            await unit.PermisoRepo.Update(permiso);
            await unit.PermisoRepo.Save();
            logger.LogInformation($"Permiso modificado para el usuario {permiso.NombreEmpleado+" "+permiso.ApellidoEmpleado}");

            return Ok();


        }

        [HttpPost("solicitarpermiso")]
        public async Task<ActionResult> Post(PermisoCreacionDTO permisoCreacionDTO)
        {
            if (permisoCreacionDTO.TipoPermisoId == 0)
            {
                logger.LogWarning("No se puede guardar un permiso sin un tipo de permiso");
                return BadRequest("No se puede guardar un permiso sin un tipo de permiso");
            }

            bool existsId= await unit.TipoPermisoRepo.existsAsync(permisoCreacionDTO.TipoPermisoId);

            if (!existsId)
            {
                logger.LogWarning("Tipo de permiso incorrecto");
                return BadRequest("Tipo permiso incorrecto");
            }

            bool exists = await unit.PermisoRepo.existsAsync(permisoCreacionDTO);
            if (exists)
            {
                logger.LogWarning("Ya existe un usuario con los mismos datos");
                return BadRequest("Ya existe un usuario con los mismos datos");
            }

            var permiso = mapper.Map<Permiso>(permisoCreacionDTO);
            await unit.PermisoRepo.Add(permiso);
            await unit.PermisoRepo.Save();
            logger.LogInformation("Permiso guardado");
            return Ok("Permiso guardado");

        }
    }
}
