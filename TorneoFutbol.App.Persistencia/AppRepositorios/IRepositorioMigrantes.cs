using System.Collections.Generic;
using TorneoFutbol.App.Dominio;

namespace TorneoFutbol.App.Persistencia
{
    public interface IRepositorioMigrantes
    {   
        IEnumerable<Migrante> GetAllMigrante();
        Migrante AddMigrante(Migrante migrante);
        Migrante UpdateMigrante(Migrante migrante);
        void DeleteMigrante(int idMigrante);
        Migrante GetMigrante(int idMigrante);
        public IEnumerable<Migrante> GetMigranteNombre(string nombre);

        Grupo AsignarGrupo(int IdMigrante, int IdGrupo);

        
    }
}