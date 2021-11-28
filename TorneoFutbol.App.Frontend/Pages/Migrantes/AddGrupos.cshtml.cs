using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;


namespace TorneoFutbol.App.Frontend.Pages.Migrantes
{
    public class AddGruposModel : PageModel
    {
        private readonly IRepositorioMigrantes _repoMigrante;
        private readonly IRepositorioGrupos _repoGrupo;
        public Migrante migrante {get; set;}
        public IEnumerable<Grupo> grupo {get; set;}
        public AddGrupo(IRepositorioMigrantes repoMigrante, IRepositorioGrupos repoGrupo)
        {
            _repoMigrante = repoMigrante;
            _repoGrupo = repoGrupo;
        }
        public void OnGet(int Id)
        {
            migrante = _repoMigrante.GetMigrante(Id);
            grupo = _repoGrupo.GetAllGrupos();
        }

        public IActionResult OnPost(int IdMigrante, int IdGrupo)
        {
            _repoMigrante.AsignarGrupo(IdMigrante, IdGrupo);
            return RedirectToPage("Details", new{Id = IdMigrante});
        }
    }
}
