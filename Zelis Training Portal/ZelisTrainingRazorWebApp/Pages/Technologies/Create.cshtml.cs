using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ZelisTrainingLibrary.Models;
using ZelisTrainingLibrary.Repos;

namespace ZelisTrainingRazorWebApp.Pages.Technologies
{
    public class CreateModel : PageModel
    {
        [BindProperty]
        public Technology technology { get; set; }
        ITechnologyRepository techRepo = new ADOTechnologyRepository();
        public void OnGet()
        {
        }
        public IActionResult OnPost()
        {
            techRepo.NewTechnology(technology);
            return RedirectToPage("/Technologies/Index");
        }
    }
}
