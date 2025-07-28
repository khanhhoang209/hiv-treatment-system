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

namespace Application.Pages.Clinics
{
    public class CreateModel : PageModel
    {
        private readonly IClinicService _clinicService;

        public CreateModel(IClinicService clinicService)
        {
            _clinicService = clinicService;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Clinic Clinic { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            await _clinicService.CreateClinic(Clinic);

            return RedirectToPage("./Index");
        }
    }
}