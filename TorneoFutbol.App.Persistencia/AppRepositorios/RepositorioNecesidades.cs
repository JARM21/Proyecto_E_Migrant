using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using TorneoFutbol.App.Dominio;

namespace TorneoFutbol.App.Persistencia
{
    public class RepositorioNecesidades : IRepositorioNecesidades
    {
        private readonly AppContext _appContext = new AppContext();
        

        Necesidad IRepositorioNecesidades.AddNecesidades(Necesidad necesidades)
        {
            var NecesidadAdicionado = _appContext.Necesidades.Add(necesidades);
            _appContext.SaveChanges();
            return NecesidadAdicionado.Entity;
        }

        void IRepositorioNecesidades.DeleteNecesidades(int idNecesidades)
        {
            var necesidadEncontrado=_appContext.Necesidades.FirstOrDefault(p=>p.Id==idNecesidades);
            if(necesidadEncontrado==null)
                return;
            _appContext.Necesidades.Remove(necesidadEncontrado);
            _appContext.SaveChanges();
        }

        IEnumerable<Necesidad> IRepositorioNecesidades.GetAllNecesidades()
        {
            return _appContext.Necesidades;
        }

        Necesidad IRepositorioNecesidades.GetNecesidad(int idNecesidad)
        {
            return _appContext.Necesidades.FirstOrDefault(p=>p.Id==idNecesidad);
            
        }

        Necesidad IRepositorioNecesidades.UpdateNecesidad(Necesidad necesidad)
        {
            var necesidadEncontrado=_appContext.Necesidades.FirstOrDefault(p=>p.Id==necesidad.Id);
            if(necesidadEncontrado!=null)
            {
                necesidadEncontrado.Nombre_Nesesidad = necesidad.Nombre_Nesesidad;
                
                necesidadEncontrado.Descripcion = necesidad.Descripcion;
               
                necesidadEncontrado.Prioridad = necesidad.Prioridad;
               
                
                _appContext.SaveChanges();
            }
            return necesidadEncontrado;
        }
        public Necesidad GetNecesidad(int IdNecesidad)
        {
            var necesidad = _appContext.Necesidades
                .Where(pa => pa.Id == IdNecesidad)
                .Include(pa => pa.Migrante)
                .Include(pa => pa.Entidad)
                .FirstOrDefault();
            return necesidad;
            
        }

        Migrante IRepositorioNecesidades.AsignarMigrante(int IdNecesidad, int IdMigrante)
        { var necesidadEncontrado = _appContext.Necesidades.Find(IdNecesidad);
            if (necesidadEncontrado != null)
            { var migranteEncontrado = _appContext.Migrantes.Find(IdMigrante);
            if (migranteEncontrado != null)
            { necesidadEncontrado.Migrante = migranteEncontrado;
            _appContext.SaveChanges();
            }
            return migranteEncontrado;
            }
            return null;
        }

        Entidad IRepositorioNecesidades.AsignarEntidad(int IdNecesidad, int IdEntidad)
        { var necesidadEncontrado = _appContext.Necesidades.Find(IdNecesidad);
            if (necesidadEncontrado != null)
            { var entidadEncontrado = _appContext.Entidades.Find(IdEntidad);
            if (entidadEncontrado != null)
            { necesidadEncontrado.Entidad = entidadEncontrado;
            _appContext.SaveChanges();
            }
            return entidadEncontrado;
            }
            return null;
        }
        
    }
}