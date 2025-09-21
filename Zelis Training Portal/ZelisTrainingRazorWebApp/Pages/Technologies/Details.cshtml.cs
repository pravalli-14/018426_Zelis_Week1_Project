using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ZelisTrainingLibrary.Models;
using ZelisTrainingLibrary.Repos;

namespace ZelisTrainingRazorWebApp.Pages.Technologies
{
    public class DetailsModel : PageModel
    {
        public Technology technology { get; set; }
        ITechnologyRepository techRepo = new ADOTechnologyRepository();
        public void OnGet(int techid)
        {
            technology = techRepo.GetTechnology(techid);
        }
    }
}
