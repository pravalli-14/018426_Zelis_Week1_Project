using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ZelisTrainingLibrary.Models;
using ZelisTrainingLibrary.Repos;
namespace ZelisTrainingRazorWebApp.Pages.Trainers
{
    public class IndexModel : PageModel
    {
        public List<Trainer> trainers = new List<Trainer>();
        ITrainerRepository trainRepo = new ADOTrainerRepository();
        [BindProperty(SupportsGet = true)]
        public string TrainerType { get; set; }
        public void OnGet()
        {
            if (string.IsNullOrWhiteSpace(TrainerType))
            {
                trainers = trainRepo.GetAllTrainers();
            }
            else
            {
               trainers = trainRepo.GetTrainerByType(TrainerType);
            }
        }
    }
}
