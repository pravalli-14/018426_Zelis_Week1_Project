using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ZelisTrainingLibrary.Repos;
using ZelisTrainingLibrary.Models;
namespace ZelisTrainingRazorWebApp.Pages.Trainers
{
    public class EditModel : PageModel
    {
        [BindProperty]
        public Trainer trainer { get; set; }
        ITrainerRepository repo = new ADOTrainerRepository();
        static int trid;
        public void OnGet(int tid)
        {
            trid = tid;
            trainer = repo.GetTrainer(tid);
        }
        public IActionResult OnPost() {
            repo.UpdateTrainer(trid,trainer);
            return RedirectToPage("/Trainers/Index");
        }
    }
}
