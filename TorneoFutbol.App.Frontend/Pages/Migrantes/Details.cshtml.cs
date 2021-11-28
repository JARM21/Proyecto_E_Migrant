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
    public class DetailsModel : PageModel
    {
        private readonly IRepositorioMigrantes _repoMigrante;
        public Migrante migrante {get; set;}
        public DetailsModel(IRepositorioMigrantes repoMigrante)
        {
            _repoMigrante = repoMigrante;
        }
        public IActionResult OnGet(int id)
        {
            migrante = _repoMigrante.GetMigrante(id);
            if (migrante == null)
            {
                return NotFound();
            }
            else
            {
                return Page();
            }
        }
    }
}
