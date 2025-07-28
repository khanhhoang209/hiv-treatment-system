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

namespace Application.Pages.Doctors
{
    public class EditModel : PageModel
    {
        private readonly IDoctorService _doctorService;
        private readonly IEmployeeService _employeeService;

        public EditModel(IDoctorService doctorService, IEmployeeService employeeService)
        {
            _doctorService = doctorService;
            _employeeService = employeeService;
        }

        [BindProperty]
        public Doctor Doctor { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var doctor = await _doctorService.GetDoctorById((Guid)id);
            if (doctor == null)
            {
                return NotFound();
            }
            Doctor = doctor;
           ViewData["EmployeeId"] = new SelectList(_employeeService.GetEmployees(), "Id", "Email");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            try
            {
                await _doctorService.UpdateDoctor(Doctor);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DoctorExists(Doctor.Id))
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

        private bool DoctorExists(Guid id)
        {
            return _doctorService.GetDoctorById(id) != null;
        }
    }
}