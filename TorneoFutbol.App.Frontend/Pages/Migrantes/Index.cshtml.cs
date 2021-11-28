using System.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TorneoFutbol.App.Dominio;
using TorneoFutbol.App.Persistencia;

namespace TorneoFutbol.App.Frontend.Pages.Migrantes
{
    public class IndexModel : PageModel
    {
        private readonly IRepositorioMigrantes _repoMigrante;
        public IEnumerable <Migrante> migrante {get; set;}
        public string gActual{get; set;}

        public IndexModel(IRepositorioMigrantes repoMigrante)
        {
            _repoMigrante = repoMigrante;
        }
        public void OnGet(string g)
        {
            if (string.IsNullOrEmpty(g))
            {
                gActual = "";
                
                migrante = _repoMigrante.GetAllMigrante();
            }
            else
            {
                gActual = g;
                migrante = _repoMigrante.GetMigranteNombre(g);
            }
        }
    }
}
