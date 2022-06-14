using Challenge_n5.Data;
using Challenge_n5.Infrastructure;
using Challenge_n5.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Challenge_n5.Services
{
    public class TipoPermisoRepo : GenericRepo<TipoPermiso>, ITipoPermisoRepo
    {
        private readonly Context context;

        public TipoPermisoRepo(Context context) : base(context)
        {
            this.context = context;
        }

        public async Task<bool> existsAsync(string descripcion)
        {            
           return await context.tipoPermisos.AnyAsync(tipoPermiso => tipoPermiso.Descripcion == descripcion);            
        }

        public async Task<bool> existsAsync(int id)
        {
            return await context.tipoPermisos.AnyAsync(tipoPermiso => tipoPermiso.Id == id);
        }

        
    }
}
