using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ZelisTrainingLibrary.Models;
using ZelisTrainingLibrary.Repos;
namespace ZelisTrainingRazorWebApp.Pages.Technologies
{
    public class IndexModel : PageModel
    {
        public List<Technology> technologies = new List<Technology>();
        ITechnologyRepository techRepo = new ADOTechnologyRepository();
        [BindProperty(SupportsGet = true)]
        public string Level { get; set; }
        public void OnGet()
        {
            if (!string.IsNullOrWhiteSpace(Level))
            {
                technologies = techRepo.GetTechnologyByLevel(Level);
            }
            else
            {
                technologies = techRepo.GetAllTechnologies();
            }
        }
    }
}
