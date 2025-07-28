using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Repository.Models;
using Service.Interfaces;

namespace Application.Pages.Doctors
{
    public class CreateModel : PageModel
    {
        private readonly IDoctorService _doctorService;
        private readonly IEmployeeService _employeeService;

        public CreateModel(IDoctorService doctorService, IEmployeeService employeeService)
        {
            _doctorService = doctorService;
            _employeeService = employeeService;
        }

        public IActionResult OnGet()
        {
        ViewData["EmployeeId"] = new SelectList(_employeeService.GetEmployees(), "Id", "Email");
            return Page();
        }

        [BindProperty]
        public Doctor Doctor { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            await _doctorService.AddDoctor(Doctor);

            return RedirectToPage("./Index");
        }
    }
}