using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ZelisTrainingLibrary.Models;
using ZelisTrainingLibrary.Repos;

namespace ZelisTrainingRazorWebApp.Pages.Trainees
{
    public class CreateModel : PageModel
    {
        [BindProperty]
        public Trainee trainee { get; set; }
        ITraineeRepository repo = new ADOTraineeRepository();
        public void OnGet()
        {
        }
        public IActionResult OnPost()
        {
            repo.AddTrainee(trainee);
            return RedirectToPage("/Trainees/Index");
        }
    }
}
