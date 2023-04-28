using CatalogoJuegos.Entities;
using Microsoft.EntityFrameworkCore;

namespace CatalogoJuegos.Contexts
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Empresa> Empresas { get; set; }
        public DbSet<Juego> Juegos { get; set;}
    }
}
