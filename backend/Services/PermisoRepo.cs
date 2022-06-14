using Challenge_n5.Data;
using Challenge_n5.Infrastructure;
using Challenge_n5.Models;
using Challenge_n5.Views;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections;
using System.Threading.Tasks;

namespace Challenge_n5.Services
{
    public class PermisoRepo : GenericRepo<Permiso>, IPermisoRepo
    {
        private readonly Context context;

        public PermisoRepo(Context context) : base(context)
        {
            this.context = context;
        }

        public async Task<bool> existsAsync(PermisoCreacionDTO permisoDTO)
        {
            return await context.permisos.AnyAsync(permiso => permiso.NombreEmpleado==permisoDTO.NombreEmpleado && permiso.ApellidoEmpleado==permisoDTO.ApellidoEmpleado && permiso.TipoPermisoId==permisoDTO.TipoPermisoId);
        }

        public async Task<bool> different(PermisoDTO permisoDTO)
        {
            return await context.permisos.AnyAsync(permiso =>permiso.Id!=permisoDTO.Id && permiso.NombreEmpleado==permisoDTO.NombreEmpleado && permiso.ApellidoEmpleado==permisoDTO.ApellidoEmpleado && permiso.TipoPermisoId==permisoDTO.TipoPermisoId);
        }

        public async Task<IEnumerable> GetWithPermissionAsync()
        {
           return await context.permisos.Include(x => x.TipoPermiso).ToListAsync();
        }
    }
}
