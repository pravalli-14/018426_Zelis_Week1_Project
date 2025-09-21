using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ZelisTrainingLibrary.Models;
using ZelisTrainingLibrary.Repos;

namespace ZelisTrainingRazorWebApp.Pages.Trainings
{
    public class IndexModel : PageModel
    {
        public List<Training> trainings = new List<Training>();
        ITrainingRepository trainRepo = new ADOTrainingRepository();

        [BindProperty(SupportsGet = true)]
        public int? TrainerId { get; set; }
        public int? TechId { get; set; }
        public void OnGet()
        {
            if (TrainerId == null && TechId == null)
            {
                trainings = trainRepo.GetAllTrainings(); // No filter
            }
            else if (TrainerId != null)
            {
                trainings = trainRepo.GetTrainingByTrainerId(TrainerId.Value);
            }
            else if (TechId != null)
            {
                trainings = trainRepo.GetTrainingByTechnologyId(TechId.Value);
            }
        }
    }
}
