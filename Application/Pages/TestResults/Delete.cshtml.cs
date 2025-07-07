using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Repository.Context;
using Repository.Models;

namespace Application.Pages.TestResults
{
    public class DeleteModel : PageModel
    {
        private readonly Repository.Context.ApplicationDbContext _context;

        public DeleteModel(Repository.Context.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public TestResult TestResult { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var testresult = await _context.TestResults.FirstOrDefaultAsync(m => m.Id == id);

            if (testresult == null)
            {
                return NotFound();
            }
            else
            {
                TestResult = testresult;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var testresult = await _context.TestResults.FindAsync(id);
            if (testresult != null)
            {
                TestResult = testresult;
                _context.TestResults.Remove(TestResult);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
