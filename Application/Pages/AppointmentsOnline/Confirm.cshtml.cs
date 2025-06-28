using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repository.Context;

namespace Application.Pages.Appointments
{
    public class ConfirmModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _config;

        public ConfirmModel(ApplicationDbContext context, IConfiguration config)
        {
            _context = context;
            _config = config;
        }

        public async Task<IActionResult> OnGetAsync(Guid id)
        {
            var appointment = await _context.Appointments.FindAsync(id);
            if (appointment == null) return NotFound();

            appointment.Status = "Confirmed";

            // Thêm link Google Meet vào Note
            if (string.IsNullOrWhiteSpace(appointment.Notes))
            {
                appointment.Notes = $"Google Meet Link: {_config["LinkGGMeet"]}";
            }
            else
            {
                appointment.Notes += $" - Google Meet Link:{_config["LinkGGMeet"]}";
            }

            await _context.SaveChangesAsync();

            return RedirectToPage("List");
        }
    }
}
