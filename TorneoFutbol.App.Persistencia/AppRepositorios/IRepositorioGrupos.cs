using System.Collections.Generic;
using TorneoFutbol.App.Dominio;

namespace TorneoFutbol.App.Persistencia
{
    public interface IRepositorioGrupos
    {   
        IEnumerable<Grupo> GetAllGrupos();
        Grupo AddGrupo(Grupo grupo);
        Grupo UpdateGrupo(Grupo grupo);
        void DeleteGrupo(int idGrupo);
        Grupo GetGrupo(int idGrupo);
        public IEnumerable<Grupo> GetGrupoNombre(string nombre);
    }
}