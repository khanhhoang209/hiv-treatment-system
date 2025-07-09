using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Repository.Context;
using Repository.Models;

namespace Application.Pages.MedicalRecords
{
    public class DeleteModel : PageModel
    {
        private readonly Repository.Context.ApplicationDbContext _context;

        public DeleteModel(Repository.Context.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public MedicalRecord MedicalRecord { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medicalrecord = await _context.MedicalRecords.FirstOrDefaultAsync(m => m.Id == id);

            if (medicalrecord == null)
            {
                return NotFound();
            }
            else
            {
                MedicalRecord = medicalrecord;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medicalrecord = await _context.MedicalRecords.FindAsync(id);
            if (medicalrecord != null)
            {
                MedicalRecord = medicalrecord;
                _context.MedicalRecords.Remove(MedicalRecord);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
