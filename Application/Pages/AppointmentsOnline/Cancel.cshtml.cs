using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repository.Context;

namespace Application.Pages.Appointments
{
    public class CancelModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public CancelModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> OnGetAsync(Guid id)
        {
            var appointment = await _context.Appointments.FindAsync(id);
            if (appointment == null) return NotFound();

            appointment.Status = "Cancelled";
            await _context.SaveChangesAsync();

            return RedirectToPage("List");
        }
    }
}
