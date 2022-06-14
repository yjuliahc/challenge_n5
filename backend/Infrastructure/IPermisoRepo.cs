using Challenge_n5.Models;
using Challenge_n5.Views;
using System.Collections;
using System.Threading.Tasks;

namespace Challenge_n5.Infrastructure
{
    public interface IPermisoRepo:IGenericRepo<Permiso>
    {
        Task<bool> existsAsync(PermisoCreacionDTO permisoDTO);
        Task<bool> different(PermisoDTO permisoDTO);

        Task<IEnumerable> GetWithPermissionAsync();
    }
}
