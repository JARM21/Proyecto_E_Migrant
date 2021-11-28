using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TorneoFutbol.App.Dominio;
using TorneoFutbol.App.Persistencia;

namespace TorneoFutbol.App.Frontend.Pages.Grupos
{
    public class IndexModel : PageModel
    {
        private readonly IRepositorioGrupos _repoGrupo;
        public IEnumerable <Grupo> grupo {get; set;}
        public Grupo Grupo{get; set;}
        public string gActual{get; set;}
        

        public IndexModel(IRepositorioGrupos repoGrupo)
        {
            _repoGrupo = repoGrupo;
        }

        public void OnGet(string g)
        {
            if (string.IsNullOrEmpty(g))
            {
                gActual = "";
                
                grupo = _repoGrupo.GetAllGrupos();
            }
            else
            {
                gActual = g;
                grupo = _repoGrupo.GetGrupoNombre(g);
            }
            
        }
     
        
    }
}
