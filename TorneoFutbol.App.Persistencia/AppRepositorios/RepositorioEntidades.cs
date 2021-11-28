using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using TorneoFutbol.App.Dominio;

namespace TorneoFutbol.App.Persistencia
{
    public class RepositorioEntidades : IRepositorioEntidades
    {
        private readonly AppContext _appContext = new AppContext();
        

        Entidad IRepositorioEntidades.AddEntidades(Entidad Entidades)
        {
            var EntidadAdicionado = _appContext.Entidades.Add(Entidades);
            _appContext.SaveChanges();
            return EntidadAdicionado.Entity;
        }

        void IRepositorioEntidades.DeleteEntidades(int IdEntidades)
        {
            var EntidadEncontrado=_appContext.Entidades.FirstOrDefault(m=>m.Id==IdEntidades);
            if(EntidadEncontrado==null)
                return;
            _appContext.Entidades.Remove(EntidadEncontrado);
            _appContext.SaveChanges();
        }

        IEnumerable<Entidad> IRepositorioEntidades.GetAllEntidades()
        {
            return _appContext.Entidades;
        }

        public Entidad GetEntidades(int IdEntidades)
        {
            var entidad = _appContext.Entidades
                .Where(p => p.Id == IdEntidades)
                .Include(p => p.Migrante)
                //.Include(p => p.DirectorTecnico)
                
                .FirstOrDefault();
            return entidad;
            
        }

        Entidad IRepositorioEntidades.UpdateEntidades(Entidad Entidad)
        {
            var EntidadEncontrado=_appContext.Entidades.FirstOrDefault(m=>m.Id==Entidad.Id);
            if(EntidadEncontrado!=null)
            {
                EntidadEncontrado.Razon_Social = Entidad.Razon_Social;
                EntidadEncontrado.Nit = Entidad.Nit;
                EntidadEncontrado.Direccion = Entidad.Direccion;
                EntidadEncontrado.Ciudad = Entidad.Ciudad;
                EntidadEncontrado.Teléfono = Entidad.Teléfono;
                EntidadEncontrado.Sector = Entidad.Sector;
                EntidadEncontrado.Tipo_Servicio = Entidad.Tipo_Servicio;
                EntidadEncontrado.Direccion_Electronica = Entidad.Direccion_Electronica;
                EntidadEncontrado.Pagina_Web = Entidad.Pagina_Web;
                
                
                _appContext.SaveChanges();
            }
            return EntidadEncontrado;
        }

        Migrante IRepositorioEntidades.AsignarMigrante(int IdEntidad, int IdMigrante)
        { var EntidadEncontrado = _appContext.Entidades.Find(IdEntidad);
            if (EntidadEncontrado != null)
            { var migranteEncontrado = _appContext.Migrantes.Find(IdMigrante);
            if (migranteEncontrado != null)
            { EntidadEncontrado.Migrante = migranteEncontrado;
            _appContext.SaveChanges();
            }
            return migranteEncontrado;
            }
            return null;
        }

        /*DirectorTecnico IRepositorioEntidades.AsignarDirectorTecnico(int IdEntidad, int IdDirectorTecnico)
        { var EntidadEncontrado = _appContext.Entidades.Find(IdEntidad);
            if (EntidadEncontrado != null)
            { var directortecnicoEncontrado = _appContext.DirectoresTecnicos.Find(IdDirectorTecnico);
            if (directortecnicoEncontrado != null)
            { EntidadEncontrado.DirectorTecnico = directortecnicoEncontrado;
            _appContext.SaveChanges();
            }
            return directortecnicoEncontrado;
            }
            return null;
        }*/
        public IEnumerable<Entidad> GetEntidadNombre(string nombre)
        {
            return _appContext.Entidades
                   .Where(P => P.Razon_Social.Contains(nombre));
        }

        
    }
}
