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

namespace Application.Pages.Clinics
{
    public class DetailsModel : PageModel
    {
        private readonly IClinicService _clinicService;

        public DetailsModel(IClinicService clinicService)
        {
            _clinicService = clinicService;
        }

        public Clinic Clinic { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clinic = await _clinicService.GetClinicById((Guid)id);
            if (clinic == null)
            {
                return NotFound();
            }
            else
            {
                Clinic = clinic;
            }
            return Page();
        }
    }
}