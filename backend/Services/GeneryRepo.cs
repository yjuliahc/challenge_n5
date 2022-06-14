using Challenge_n5.Data;
using Challenge_n5.Infrastructure;
using Challenge_n5.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Challenge_n5.Services
{
    public class GenericRepo<T> : IGenericRepo<T> where T:Entity, new()
    {
        private readonly Context context;
        private readonly DbSet<T> dbSet;

        public GenericRepo(Context context)
        {
            this.context = context;
            dbSet = context.Set<T>();
        }

        public async Task<T> Add(T data)
        {            
            await dbSet.AddAsync(data);
            return data;
        }


        public void Delete(int Id)
        {
            var dataToDelete = dbSet.Find(Id);
            dbSet.Remove(dataToDelete);
        }

        public async Task<IEnumerable<T>> GetAsync() => await dbSet.ToListAsync();


        public async Task<T> Get(int Id) => await dbSet.FindAsync(Id);


        public async Task Save() => await context.SaveChangesAsync();


        public async Task<T> Update(T data)
        {                      
            dbSet.Attach(data);
            context.Entry(data).State = EntityState.Modified;
            return data;
        }
    }
}
