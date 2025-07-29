using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Repository.Context;
using Repository.Models;
using Service.Interfaces;

namespace Application.Pages.Staffs
{
    public class CreateModel : PageModel
    {
        private readonly IStaffService _staffService;
        private readonly IEmployeeService _employeeService;

        public CreateModel(IStaffService staffService, IEmployeeService employeeService)
        {
            _staffService = staffService;
            _employeeService = employeeService;
        }

        public IActionResult OnGet()
        {
        ViewData["EmployeeId"] = new SelectList(_employeeService.GetEmployees(), "Id", "Email");
            return Page();
        }

        [BindProperty]
        public Staff Staff { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            await _staffService.CreateAsync(Staff);

            return RedirectToPage("./Index");
        }
    }
}