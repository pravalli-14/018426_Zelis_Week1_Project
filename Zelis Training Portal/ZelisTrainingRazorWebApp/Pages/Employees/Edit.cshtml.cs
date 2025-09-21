using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ZelisTrainingLibrary.Models;
using ZelisTrainingLibrary.Repos;

namespace ZelisTrainingRazorWebApp.Pages.Employees
{
    public class EditModel : PageModel
    {
        [BindProperty]
        public Employee employee { get; set; }
        IEmployeeRepository empRepo = new ADOEmployeeRepository();
        static int eid;
        public void OnGet(int empid)
        {
            eid = empid;
            employee = empRepo.GetEmployeeById(empid);
        }
        public IActionResult OnPost()
        {
            empRepo.UpdateEmployee(eid,employee);
            return RedirectToPage("/Employees/Index");
        }
    }
}
