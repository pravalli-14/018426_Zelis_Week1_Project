using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ZelisTrainingLibrary.Repos;
using ZelisTrainingLibrary.Models;
namespace ZelisTrainingRazorWebApp.Pages.Employees
{
    public class DetailsModel : PageModel
    {
        public Employee employee { get; set; }
        IEmployeeRepository empRepo = new ADOEmployeeRepository();

        public void OnGet(int empid)
        {
            employee = empRepo.GetEmployeeById(empid);
        }
    }
}
