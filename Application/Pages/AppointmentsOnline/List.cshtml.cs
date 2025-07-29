using Application.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
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
            var currentUserId = HttpContext.GetUserId();
            if (currentUserId == Guid.Empty)
            {
                ModelState.AddModelError("", "Vui lòng đăng nhập để đặt lịch hẹn.");
                return Page();
            }

            Appointments = await _appointmentService.GetAppointmentsByUserIdAsync(currentUserId);

            return Page();
        }
    }
}
