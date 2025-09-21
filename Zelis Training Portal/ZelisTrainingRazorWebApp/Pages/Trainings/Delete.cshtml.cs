using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ZelisTrainingLibrary.Models;
using ZelisTrainingLibrary.Repos;

namespace ZelisTrainingRazorWebApp.Pages.Trainings
{
    public class DeleteModel : PageModel
    {
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
            repo.DeleteTraining(trid);
            return RedirectToPage("/Trainings/Index");
        }
    }
}
