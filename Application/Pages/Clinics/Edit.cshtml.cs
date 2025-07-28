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

namespace Application.Pages.Clinics
{
    public class EditModel : PageModel
    {
        private readonly IClinicService _clinicService;

        public EditModel(IClinicService clinicService)
        {
            _clinicService = clinicService;
        }

        [BindProperty]
        public Clinic Clinic { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clinic =  await _clinicService.GetClinicById((Guid)id);
            if (clinic == null)
            {
                return NotFound();
            }
            Clinic = clinic;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            try
            {
                await _clinicService.UpdateClinic(Clinic);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClinicExists(Clinic.Id))
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

        private bool ClinicExists(Guid id)
        {
            return _clinicService.GetClinicById((Guid)id) != null!;
        }
    }
}