using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ZelisTrainingLibrary.Models;
using ZelisTrainingLibrary.Repos;

namespace ZelisTrainingRazorWebApp.Pages.Trainees
{
    public class DetailsModel : PageModel
    {
        public Trainee trainee { get; set; }
        ITraineeRepository repo = new ADOTraineeRepository();
        static int trainId, eid;
        public void OnGet(int tid,int empid)
        {
            trainId = tid;
            eid = empid;
            trainee = repo.GetTrainee(tid,empid);
        }
    }
}
