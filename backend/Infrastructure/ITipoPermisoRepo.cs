using Challenge_n5.Models;
using System.Threading.Tasks;

namespace Challenge_n5.Infrastructure
{
    public interface ITipoPermisoRepo: IGenericRepo<TipoPermiso>
    {
        Task<bool> existsAsync(string descripcion);
        Task<bool> existsAsync(int id);

        
    }
}
