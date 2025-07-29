using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Repository.Context;
using Repository.Interfaces;
using Repository.Models;
using Service.Interfaces;

namespace Application.Pages.Appointments
{
    public class IndexModel : PageModel
    {
        private readonly IDoctorService _doctorService;
        private readonly IAppointmentService _service;
        public IndexModel(IDoctorService doctorService, IAppointmentService service)
        {
            _doctorService = doctorService;
            _service = service;
        }

        public IList<Appointment> Appointment { get;set; } = default!;

        public async Task<IActionResult> OnGetAsync()
        {
            var role= HttpContext.Session.GetString("Role");
            var userIdStr = HttpContext.Session.GetString("Account");
            if (string.IsNullOrEmpty(role) || string.IsNullOrEmpty(userIdStr))
            {
                return RedirectToPage("/Login");
            }

            if (role == "User" && Guid.TryParse(userIdStr, out var userId))
            {
               Appointment = await _service.GetAppointmentByUserId(userId);
            }

            if (role == "Doctor")
            {
                var doctor = await _doctorService.GetDoctorByUserIdAsync(Guid.Parse(userIdStr));
                if (doctor == null)
                {
                    return RedirectToPage("/Error");
                }
                Appointment = await _service.GetAppointmentByDoctorId(doctor.Id);
            }
            if(role == "Admin")
            {
                Appointment = await _service.GetAllAppointments();
            }

            return Page();
        }
    }
}
