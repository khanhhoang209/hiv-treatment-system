using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Repository.Context;
using Repository.Models;
using Service.DTO;
using Service.Interfaces;
using Application.Extensions;

namespace Application.Pages.AppointmentsOnline
{
    public class CreateModel : PageModel
    {
        private readonly IAppointmentOnlService _appointmentService;
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _configuration;

        public CreateModel(IAppointmentOnlService appointmentService, ApplicationDbContext context, IConfiguration configuration)
        {
            _appointmentService = appointmentService;
            _context = context;
            _configuration = configuration;
        }

        [BindProperty]
        public AppointmentRequest Appointment { get; set; } = new AppointmentRequest();

        public SelectList DoctorList { get; set; } = null!;

        public async Task<IActionResult> OnGetAsync()
        {
            var doctors = await _context.Doctors.ToListAsync();
            DoctorList = new SelectList(doctors, "Id", "Specialization");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            // Validate appointment date - must be at least 1 day from now
            var minDate = DateTime.Today.AddDays(1);
            if (Appointment.AppointmentDate.Date < minDate)
            {
                ModelState.AddModelError("Appointment.AppointmentDate", "Ngày hẹn phải cách hôm nay ít nhất 1 ngày.");
            }

            if (!ModelState.IsValid)
            {
                // Reload doctors for dropdown if validation fails
                var doctors = await _context.Doctors.ToListAsync();
                DoctorList = new SelectList(doctors, "Id", "Specialization");
                return Page();
            }

            // Get current logged in user ID from session
            var currentUserId = HttpContext.GetUserId();
            if (currentUserId == Guid.Empty)
            {
                ModelState.AddModelError("", "Vui lòng đăng nhập để đặt lịch hẹn.");
                var doctors = await _context.Doctors.ToListAsync();
                DoctorList = new SelectList(doctors, "Id", "Specialization");
                return Page();
            }

            // Get current user for online appointments
            var currentUser = await _context.Users.FirstOrDefaultAsync(u => u.Id == currentUserId);
            if (currentUser == null)
            {
                ModelState.AddModelError("", "Không tìm thấy thông tin người dùng. Vui lòng liên hệ quản trị viên.");
                var doctors = await _context.Doctors.ToListAsync();
                DoctorList = new SelectList(doctors, "Id", "Specialization");
                return Page();
            }

            // Get Google Meet link from appsettings
            var googleMeetLink = _configuration["LinkGGMeet"];
            var notesWithLink = Appointment.Notes;
            if (!string.IsNullOrEmpty(googleMeetLink))
            {
                notesWithLink += $"- Link khám online: {googleMeetLink}";
            }

            Appointment appointment = new Appointment()
            {
                AppointmentDate = Appointment.AppointmentDate,
                DoctorId = Appointment.DoctorId,
                UserId = currentUser.Id,
                Notes = $"{notesWithLink}"
            };
            await _appointmentService.CreateAppointmentAsync(appointment);
            return RedirectToPage("../AppointmentsOnline/List");
        }
    }
}
