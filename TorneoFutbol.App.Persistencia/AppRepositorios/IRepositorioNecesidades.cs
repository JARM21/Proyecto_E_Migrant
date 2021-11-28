using System.Collections.Generic;
using TorneoFutbol.App.Dominio;

namespace TorneoFutbol.App.Persistencia
{
    public interface IRepositorioNecesidades
    {   
        IEnumerable<Necesidad> GetAllNecesidades();
        Necesidad AddNecesidades(Necesidad necesidades);
        Necesidad UpdateNecesidad(Necesidad necesidades);
        void DeleteNecesidades(int necesidades);
        Necesidad GetNecesidad(int necesidades);
        Entidad AsignarEntidad(int IdNecesidad, int IdEntidad);
        Migrante AsignarMigrante(int IdNecesidad, int IdMigrante);
       
    }
}