using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ZelisTrainingLibrary.Models;
using ZelisTrainingLibrary.Repos;

namespace ZelisTrainingRazorWebApp.Pages.Trainings
{
    public class DetailsModel : PageModel
    {
        public Training training { get; set; }
        ITrainingRepository repo = new ADOTrainingRepository();

        public void OnGet(int trainingid)
        {
            training = repo.GetTraining(trainingid);
        }
    }
}
