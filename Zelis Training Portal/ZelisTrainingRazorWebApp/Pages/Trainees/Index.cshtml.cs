using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ZelisTrainingLibrary.Models;
using ZelisTrainingLibrary.Repos;

namespace ZelisTrainingRazorWebApp.Pages.Trainees
{
    public class IndexModel : PageModel
    {
        public List<Trainee> trainees = new List<Trainee>();
        ITraineeRepository tRepo = new ADOTraineeRepository();

        [BindProperty(SupportsGet = true)]
        public int? EmpId { get; set; }

        [BindProperty(SupportsGet = true)]
        public int? TrainingId { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? Status { get; set; }

        public void OnGet()
        {
            if (EmpId.HasValue)
            {
                trainees = tRepo.GetTraineesByEmpId(EmpId.Value);
            }
            else if (TrainingId.HasValue)
            {
                trainees = tRepo.GetTraineesByTrainingId(TrainingId.Value);
            }
            else if (!string.IsNullOrWhiteSpace(Status))
            {
                trainees = tRepo.GetTraineesByStatus(Status[0]);
            }
            else
            {
                trainees = tRepo.GetAllTrainees();
            }
        }
    }
}