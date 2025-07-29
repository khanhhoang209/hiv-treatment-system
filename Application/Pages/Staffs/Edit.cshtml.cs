using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Repository.Context;
using Repository.Models;
using Service.Interfaces;

namespace Application.Pages.Staffs
{
    public class EditModel : PageModel
    {
        private readonly IStaffService _staffService;
        private readonly IEmployeeService _employeeService;

        public EditModel(IStaffService staffService, IEmployeeService employeeService)
        {
            _staffService = staffService;
            _employeeService = employeeService;
        }

        [BindProperty]
        public Staff Staff { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var staff =  await _staffService.GetStaffByIdAsync(id.Value);
            if (staff == null)
            {
                return NotFound();
            }
            Staff = staff;
           ViewData["EmployeeId"] = new SelectList(_employeeService.GetEmployees(), "Id", "Email");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {

            try
            {
                await _staffService.UpdateAsync(Staff);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StaffExists(Staff.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool StaffExists(Guid id)
        {
            return _staffService.GetStaffByIdAsync(id) != null!;
        }
    }
}