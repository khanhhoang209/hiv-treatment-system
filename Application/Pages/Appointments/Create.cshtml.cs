using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        private readonly Repository.Context.ApplicationDbContext _context;
        private readonly IAppointmentService _service;
        private readonly IDoctorService _doctorService;

        public CreateModel(Repository.Context.ApplicationDbContext context,
            IAppointmentService service, IDoctorService doctorService)
        {
            _service = service;
            _context = context;
            _doctorService = doctorService;
        }

        public async Task<IActionResult> OnGet()
        {
            var role = HttpContext.Session.GetString("Role");
            var userIdStr = HttpContext.Session.GetString("Account");
            if (string.IsNullOrEmpty(role) || string.IsNullOrEmpty(userIdStr))
            {
                return RedirectToPage("/Login");
            }
            if (role == "Admin")
            {
                return RedirectToPage("/Appointments/Index");
            }
            var doctors = await _doctorService.GetDoctors();
            ViewData["DoctorId"] = new SelectList(
                doctors.Select(d => new {
                    d.Id,
                    FullName = d.Employee.FirstName + " " + d.Employee.LastName + " (" + d.LicenseNumber + ")"
                }),
                "Id", "FullName", Appointment?.DoctorId);
            return Page();
        }

        [BindProperty]
        public Appointment Appointment { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            ModelState.Remove("Appointment.Doctor");
            if (!ModelState.IsValid)
            {
                LoadSelectLists();
                return Page();
            }
            var minDate = DateTime.Today.AddDays(2);
            if (Appointment.AppointmentDate.Date < minDate)
            {
                ModelState.AddModelError("Appointment.AppointmentDate", "Ngày hẹn phải cách hôm nay ít nhất 2 ngày.");
                LoadSelectLists();
                return Page();
            }
            var userIdString = HttpContext.Session.GetString("Account");
            if (!Guid.TryParse(userIdString, out var userId))
            {
                return RedirectToPage("/Login");
            }
            Appointment.UserId = userId;
            await _service.CreateAppointmentWithScheduleAsync(Appointment);

            return RedirectToPage("./Index");
        }
        private async Task LoadSelectLists()
        {
            var doctors = await _doctorService.GetDoctors();
            ViewData["DoctorId"] = new SelectList(
                doctors.Select(d => new {
                    d.Id,
                    FullName = d.Employee.FirstName + " " + d.Employee.LastName + " (" + d.LicenseNumber + ")"
                }),
                "Id", "FullName", Appointment?.DoctorId);
        }
    }

}
