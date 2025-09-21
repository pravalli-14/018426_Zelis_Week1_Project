using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ZelisTrainingLibrary.Models;
using ZelisTrainingLibrary.Repos;

namespace ZelisTrainingRazorWebApp.Pages.Trainings
{
    public class CreateModel : PageModel
    {
        [BindProperty]
        public Training training { get; set; }
        ITrainingRepository repo = new ADOTrainingRepository();
        public void OnGet()
        {
        }
        public IActionResult OnPost()
        {
            repo.AddTraining(training);
            return RedirectToPage("/Trainings/Index");
        }
    }
}
