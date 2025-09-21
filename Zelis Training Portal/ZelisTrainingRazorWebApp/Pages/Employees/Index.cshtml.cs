using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ZelisTrainingLibrary.Models;
using ZelisTrainingLibrary.Repos;
namespace ZelisTrainingRazorWebApp.Pages.Employees
{
    public class IndexModel : PageModel
    {
        IEmployeeRepository empRepo = new ADOEmployeeRepository();

        public List<Employee> employees = new List<Employee>();

        [BindProperty(SupportsGet = true)]
        public string Designation { get; set; }

        public void OnGet()
        {
            if (string.IsNullOrWhiteSpace(Designation))
            {
                employees = empRepo.GetAllEmployees();
            }
            else
            {
                employees = empRepo.GetEmployeesByDesignation(Designation);
            }
        }
    }
}
