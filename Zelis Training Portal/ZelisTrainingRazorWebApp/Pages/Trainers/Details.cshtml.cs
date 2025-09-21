using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ZelisTrainingLibrary.Models;
using ZelisTrainingLibrary.Repos;

namespace ZelisTrainingRazorWebApp.Pages.Trainers
{
    public class DetailsModel : PageModel
    {
        public Trainer trainer { get; set; }
        ITrainerRepository repo = new ADOTrainerRepository();

        public void OnGet(int trainerid)
        {
            trainer = repo.GetTrainer(trainerid);
        }
    }
}
