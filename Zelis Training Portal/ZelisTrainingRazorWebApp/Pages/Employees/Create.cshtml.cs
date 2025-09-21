using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ZelisTrainingLibrary.Repos;
using ZelisTrainingLibrary.Models;
namespace ZelisTrainingRazorWebApp.Pages.Employees
{
    public class CreateModel : PageModel
    {
        [BindProperty]
        public Employee employee { get; set; }
        IEmployeeRepository empRepo = new ADOEmployeeRepository();
        public void OnGet()
        {
        }
        public IActionResult OnPost()
        {
            empRepo.AddEmployee(employee);
            return RedirectToPage("/Employees/Index");
        }
    }
}
