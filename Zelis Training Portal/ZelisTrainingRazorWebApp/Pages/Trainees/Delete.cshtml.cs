using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ZelisTrainingLibrary.Models;
using ZelisTrainingLibrary.Repos;

namespace ZelisTrainingRazorWebApp.Pages.Trainees
{
    public class DeleteModel : PageModel
    {
        public Trainee trainee { get; set; }
        ITraineeRepository repo = new ADOTraineeRepository();
        static int trid,eid;
        public void OnGet(int tid,int empid)
        {
            trid = tid;
            eid = empid;
            trainee = repo.GetTrainee(tid,empid);
        }
        public IActionResult OnPost()
        {
            repo.DeleteTrainee(trid,eid);
            return RedirectToPage("/Trainees/Index");
        }
    }
}
