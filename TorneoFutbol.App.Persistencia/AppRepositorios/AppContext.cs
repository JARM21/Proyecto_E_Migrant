using Microsoft.EntityFrameworkCore;
using TorneoFutbol.App.Dominio;
namespace TorneoFutbol.App.Persistencia
{
    public class AppContext : DbContext
    {
        
        public DbSet<Servicio> Servicios{get; set;}
        public DbSet<Grupo> Grupos{get; set;}
        public DbSet<Entidad> Entidades{get; set;}
        public DbSet<Migrante> Migrantes{get; set;}
        public DbSet<Necesidad> Necesidades{get; set;}
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=E_Migrant");
            }
        }
    }
}




