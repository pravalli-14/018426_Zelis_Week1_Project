using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ZelisTrainingLibrary.Models;
using ZelisTrainingLibrary.Repos;
namespace ZelisTrainingRazorWebApp.Pages.Technologies
{
    public class EditModel : PageModel
    {
        [BindProperty]
        public Technology technology { get; set; }
        ITechnologyRepository techRepo = new ADOTechnologyRepository();
        static int eid;
        public void OnGet(int empid)
        {
            eid = empid;
            technology = techRepo.GetTechnology(empid);
        }
        public IActionResult OnPost()
        {
            techRepo.UpdateTechnology(eid, technology);
            return RedirectToPage("/Technologies/Index");
        }
    }
}
