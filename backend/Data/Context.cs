using Challenge_n5.Models;
using Microsoft.EntityFrameworkCore;

namespace Challenge_n5.Data
{
    public class Context:DbContext
    {
        public Context(DbContextOptions options):base(options)
        {

        }

        public DbSet<Permiso> permisos { get; set; }
        public DbSet<TipoPermiso> tipoPermisos { get; set; }
    }
}
