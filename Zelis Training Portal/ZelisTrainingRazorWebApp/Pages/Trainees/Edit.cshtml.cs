using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ZelisTrainingLibrary.Models;
using ZelisTrainingLibrary.Repos;

namespace ZelisTrainingRazorWebApp.Pages.Trainees
{
    public class EditModel : PageModel
    {
        [BindProperty]
        public Trainee trainee { get; set; }
        ITraineeRepository repo = new ADOTraineeRepository();
        static int trid,eid;
        public void OnGet(int traineeid, int empid)
        {
            trid = traineeid;
            eid = empid;
            trainee = repo.GetTrainee(traineeid,empid);
        }
        public IActionResult OnPost()
        {
            repo.UpdateTrainee(trainee.TrainingId, trainee.EmpId, trainee.Status);
            return RedirectToPage("/Trainees/Index");
        }
    }
}
