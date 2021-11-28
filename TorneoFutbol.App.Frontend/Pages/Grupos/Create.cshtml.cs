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
    public class CreateModel : PageModel
    {
        private readonly IRepositorioGrupos _repoGrupo;
        public Grupo grupo {get; set;}
        public CreateModel(IRepositorioGrupos repoGrupos)
        {
            _repoGrupo = repoGrupos;
        }
        public void OnGet()
        {
             grupo = new Grupo();
        }

        public IActionResult OnPost(Grupo grupo)
        {
            if (ModelState.IsValid)
            {
                _repoGrupo.AddGrupo(grupo);
                return RedirectToPage("Index");
            }

            else
            {
                return Page();
            }
            
        }
    }
}
