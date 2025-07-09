using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Repository.Context;
using Repository.Models;

namespace Application.Pages.MedicalRecords
{
    public class CreateModel : PageModel
    {
        private readonly Repository.Context.ApplicationDbContext _context;

        public CreateModel(Repository.Context.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["DoctorId"] = new SelectList(_context.Doctors, "Id", "LicenseNumber");
        ViewData["UserId"] = new SelectList(_context.Users, "Id", "Address");
            return Page();
        }

        [BindProperty]
        public MedicalRecord MedicalRecord { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.MedicalRecords.Add(MedicalRecord);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
