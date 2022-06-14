using Challenge_n5.Data;
using Challenge_n5.Infrastructure;
using Challenge_n5.Models;

namespace Challenge_n5.Services
{
    public class unitOfWork : IUnitOfWork
    {
        #region declarations
        private Context context;
        private IPermisoRepo _permisoRepo;
        private ITipoPermisoRepo _tipoPermisoRepo;
        #endregion

        #region properties
        public unitOfWork(Context context)
        {
            this.context = context;
        }
        #endregion

        #region public methods
        
        public IPermisoRepo PermisoRepo
        {            
            get { return _permisoRepo ??= new PermisoRepo(context); }
        }

        public ITipoPermisoRepo TipoPermisoRepo
        {
            get { return _tipoPermisoRepo ??= new TipoPermisoRepo(context); }
        }



        public void Save()
        {
            context.SaveChanges();
        }

        public void Dispose()
        {
            context.Dispose();
        }
        #endregion
    }
}
