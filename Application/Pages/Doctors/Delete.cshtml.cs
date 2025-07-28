using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Repository.Context;
using Repository.Models;
using Service.Interfaces;

namespace Application.Pages.Doctors
{
    public class DeleteModel : PageModel
    {
        private readonly IDoctorService _doctorService;

        public DeleteModel(IDoctorService doctorService)
        {
            _doctorService = doctorService;
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
            else
            {
                Doctor = doctor;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var doctor = await _doctorService.GetDoctorById((Guid)id);
            if (doctor != null)
            {
                Doctor = doctor;
                await _doctorService.DeleteDoctor(Doctor);
            }

            return RedirectToPage("./Index");
        }
    }
}