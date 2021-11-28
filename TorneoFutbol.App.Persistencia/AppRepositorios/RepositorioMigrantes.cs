using System;
using System.Collections.Generic;
using System.Linq;
using TorneoFutbol.App.Dominio;

namespace TorneoFutbol.App.Persistencia
{
    public class RepositorioMigrantes : IRepositorioMigrantes
    {
        private readonly AppContext _appContext = new AppContext();
        
        Migrante IRepositorioMigrantes.AddMigrante(Migrante migrante)
        {
            var MigranteAdicionado = _appContext.Migrantes.Add(migrante);
            _appContext.SaveChanges();
            return MigranteAdicionado.Entity;
        }

        void IRepositorioMigrantes.DeleteMigrante(int idMigrante)
        {
            var migranteEncontrado=_appContext.Migrantes.FirstOrDefault(m=>m.Id==idMigrante);
            if(migranteEncontrado==null)
                return;
            _appContext.Migrantes.Remove(migranteEncontrado);
            _appContext.SaveChanges();
        }

        IEnumerable<Migrante> IRepositorioMigrantes.GetAllMigrante()
        {
            return _appContext.Migrantes;
        }

        Migrante IRepositorioMigrantes.GetMigrante(int idMigrante)
        {
            return _appContext.Migrantes.FirstOrDefault(m=>m.Id==idMigrante);
            
        }

        Migrante IRepositorioMigrantes.UpdateMigrante(Migrante migrante)
        {
            var migranteEncontrado=_appContext.Migrantes.FirstOrDefault(m=>m.Id==migrante.Id);
            if(migranteEncontrado!=null)
            {
                migranteEncontrado.Nombre = migrante.Nombre;
                _appContext.SaveChanges();
            }
            return migranteEncontrado;
        }

        Grupo IRepositorioMigrantes.AsignarGrupo(int IdMigrante, int IdGrupo)
        { var MigranteEncontrado = _appContext.Migrantes.Find(IdMigrante);
            if (MigranteEncontrado != null)
            { var grupoEncontrado = _appContext.Grupos.Find(IdGrupo);
            if (grupoEncontrado != null)
            { MigranteEncontrado.Grupo = grupoEncontrado;
            _appContext.SaveChanges();
            }
            return grupoEncontrado;
            }
            return null;
        }
        public IEnumerable<Migrante> GetMigranteNombre(string nombre)
        {
            return _appContext.Migrantes
                   .Where(P => P.Nombre.Contains(nombre));
        }
    }
}