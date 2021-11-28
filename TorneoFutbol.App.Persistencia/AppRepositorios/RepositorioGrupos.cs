using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using TorneoFutbol.App.Dominio;

namespace TorneoFutbol.App.Persistencia
{
    public class RepositorioGrupos : IRepositorioGrupos
    {
        private readonly AppContext _appContext = new AppContext();
        

        Grupo IRepositorioGrupos.AddGrupo(Grupo grupo)
        {
            var grupoAdicionado = _appContext.Grupos.Add(grupo);
            _appContext.SaveChanges();
            return grupoAdicionado.Entity;
        }

        void IRepositorioGrupos.DeleteGrupo(int idGrupo)
        {
            var grupoEncontrado=_appContext.Grupos.FirstOrDefault(e=>e.Id==idGrupo);
            if(grupoEncontrado==null)
                return;
            _appContext.Grupos.Remove(grupoEncontrado);
            _appContext.SaveChanges();
        }

        IEnumerable<Grupo> IRepositorioGrupos.GetAllGrupos()
        {
            return _appContext.Grupos;
        }

        Grupo IRepositorioGrupos.GetGrupo(int idGrupo)
        {
            return _appContext.Grupos.FirstOrDefault(e=>e.Id==idGrupo);
            
        }

        Grupo IRepositorioGrupos.UpdateGrupo(Grupo grupo)
        {
            var grupoEncontrado=_appContext.Grupos.FirstOrDefault(e=>e.Id==grupo.Id);
            if(grupoEncontrado!=null)
            {
                grupoEncontrado.Nombre_Grupo = grupo.Nombre_Grupo;
                grupoEncontrado.Parentesco = grupo.Parentesco;
                grupoEncontrado.Nombre_Integrante = grupo.Nombre_Integrante;
                grupoEncontrado.Cedula_Integrante = grupo.Cedula_Integrante;
                _appContext.SaveChanges();
            }
            return grupoEncontrado;
        }

        /*public Grupo GetGrupo(int IdGrupo)
        {
            var grupo = _appContext.Grupos
                .Where(e => e.Id == IdGrupo)
                .Include(e => e.Municipio)
                .FirstOrDefault();
            return grupo;
            
        }

        Municipio IRepositorioGrupos.AsignarMunicipio(int IdGrupo, int IdMunicipio)
        { var estadioEncontrado = _appContext.Grupos.Find(IdGrupo);
            if (estadioEncontrado != null)
            { var municipioEncontrado = _appContext.Municipios.Find(IdMunicipio);
            if (municipioEncontrado != null)
            { estadioEncontrado.Municipio = municipioEncontrado;
            _appContext.SaveChanges();
            }
            return municipioEncontrado;
            }
            return null;
        }*/
        public IEnumerable<Grupo> GetGrupoNombre(string nombre)
        {
            return _appContext.Grupos
                   .Where(P => P.Nombre_Grupo.Contains(nombre));
        }
    }
}