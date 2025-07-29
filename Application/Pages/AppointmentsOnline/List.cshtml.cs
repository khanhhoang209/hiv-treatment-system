using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Repository.Context;
using Repository.Models;
using Service.Interfaces;
using System.Security.Claims;

namespace Application.Pages.AppointmentsOnline
{
    public class ListModel : PageModel
    {
        private readonly IAppointmentOnlService _appointmentService;
        private readonly ApplicationDbContext _context;


        public ListModel(IAppointmentOnlService appointmentService, ApplicationDbContext context)
        {
            _appointmentService = appointmentService;
            _context = context;
        }

        public List<Appointment> Appointments { get; set; } = new();

        public async Task<IActionResult> OnGetAsync()
        {
            

            var anonymousUser = await _context.Users.FirstOrDefaultAsync(u => u.Email == "test@example.com");

            Appointments = await _appointmentService.GetAppointmentsByUserIdAsync(anonymousUser.Id);

            return Page();
        }
    }
}
