using System;
using System.Threading.Tasks;

namespace Challenge_n5.Infrastructure
{
    
        public interface IUnitOfWork : IDisposable
        {
            //public IGenericRepository<Persona> personas { get; }
            public IPermisoRepo PermisoRepo { get; }
            public ITipoPermisoRepo TipoPermisoRepo { get; }
            public void Save();
        }
        
    
}
