using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Repository.Context;
using Repository.Models;
using Service.DTO;
using Service.Interfaces;
using System.Security.Claims;

namespace Application.Pages.Appointments
{
    public class CreateModel : PageModel
    {
        private readonly IAppointmentService _appointmentService;
        private readonly ApplicationDbContext _context;

        public CreateModel(IAppointmentService appointmentService, ApplicationDbContext context)
        {
            _appointmentService = appointmentService;
            _context = context;
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
            if (!ModelState.IsValid) return Page();
            var anonymousUser = await _context.Users.FirstOrDefaultAsync(u => u.Email == "test@example.com");


            Appointment appointment = new Appointment()
            {
                AppointmentDate = Appointment.AppointmentDate,
                DoctorId = Appointment.DoctorId,
                UserId = anonymousUser.Id,
                Notes = Appointment.Notes
            };
            await _appointmentService.CreateAppointmentAsync(appointment);
            return RedirectToPage("../Appointments/List");
        }
    }
}
