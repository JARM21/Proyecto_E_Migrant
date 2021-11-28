using System.Collections.Generic;
using TorneoFutbol.App.Dominio;

namespace TorneoFutbol.App.Persistencia
{
    public interface IRepositorioEntidades
    {
        IEnumerable<Entidad> GetAllEntidades();

        Entidad AddEntidades(Entidad Entidades);

        Entidad UpdateEntidades(Entidad Entidades);

        void DeleteEntidades(int IdEntidades);

        Entidad GetEntidades(int IdEntidades);

        Migrante AsignarMigrante(int IdEntidad, int IdMigrante);

        //DirectorTecnico AsignarDirectorTecnico(int IdEquipo, int IdDirectorTecnico);
        public IEnumerable<Entidad> GetEntidadNombre(string nombre);

    }
}