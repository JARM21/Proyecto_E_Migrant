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
    public class CreateModel : PageModel
    {
        private readonly IRepositorioMigrantes _repoMigrante;
        public Migrante migrante {get; set;}

        public CreateModel(IRepositorioMigrantes repoMigrante)
        {
            _repoMigrante = repoMigrante;
        }
        public void OnGet()
        {
            migrante = new Migrante();
        }

        public IActionResult OnPost(Migrante migrante)
        {
            if (ModelState.IsValid)
            {
                _repoMigrante.AddMigrante(migrante);
                return RedirectToPage("Index");
            }
            else
            {
                return Page();
            }
        }
    }
}
