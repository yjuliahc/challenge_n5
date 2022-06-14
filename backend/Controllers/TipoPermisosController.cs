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
    public class TipoPermisosController : ControllerBase
    {
        private readonly IUnitOfWork unit;
        private readonly IMapper mapper;
        private readonly ILogger<PermisosController> logger;

        public TipoPermisosController(IUnitOfWork unit, IMapper mapper, ILogger<PermisosController> logger)
        {
            this.unit = unit;
            this.mapper = mapper;
            this.logger = logger;
        }
        /// <summary>
        /// Obtener todos los tipos de permiso
        /// </summary>
        /// <response code="200">
        /// Obtener todos los tipos de permiso
        /// </response>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TipoPermisoDTO>>> Get()
        {
            var tipoPermisos = await unit.TipoPermisoRepo.GetAsync();
            logger.LogInformation("Obteniendo los tipos de permisos");
            return mapper.Map<List<TipoPermisoDTO>>(tipoPermisos);
        }

        [HttpPost]
        public async Task<ActionResult> Post(TipoPermisoCreacionDTO tipoPermisoCreacionDTO)
        {            

            bool existeAutor = await unit.TipoPermisoRepo.existsAsync(tipoPermisoCreacionDTO.Descripcion);
            if (existeAutor)
            {
                logger.LogWarning("Ya existe un tipo de permiso con la misma descripción");
                return BadRequest("Ya existe un tipo de permiso con la misma descripción");
            }
            else
            {
                var tipoPermiso = mapper.Map<TipoPermiso>(tipoPermisoCreacionDTO);
                await unit.TipoPermisoRepo.Add(tipoPermiso);
                await unit.TipoPermisoRepo.Save();
                logger.LogInformation("Tipo de permiso guardado");
                return Ok();
            }
        }
    }
}
