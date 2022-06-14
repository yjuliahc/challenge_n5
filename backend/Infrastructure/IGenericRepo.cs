using System.Collections.Generic;
using System.Threading.Tasks;

namespace Challenge_n5.Infrastructure
{
    public interface IGenericRepo<T>
    {
        Task<IEnumerable<T>> GetAsync();
        
        Task<T> Get(int Id);
        
        Task<T> Add(T data);
        void Delete(int Id);
        Task<T> Update(T data);
        Task Save();


    }
}
