using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ZelisTrainingLibrary.Models;
using ZelisTrainingLibrary.Repos;

namespace ZelisTrainingRazorWebApp.Pages.Trainings
{
    public class EditModel : PageModel
    {
        [BindProperty]
        public Training training { get; set; }
        ITrainingRepository repo = new ADOTrainingRepository();
        static int trid;
        public void OnGet(int tid)
        {
            trid = tid;
            training = repo.GetTraining(tid);
        }
        public IActionResult OnPost()
        {
            repo.UpdateTraining(trid, training);
            return RedirectToPage("/Trainings/Index");
        }
    }
}
