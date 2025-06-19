using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Repository.Context;
using Repository.Models;
using Service.Interfaces;

namespace Application.Pages.Appointments
{
    public class DetailsModel : PageModel
    {
        public string? Role { get; set; }
        private readonly IAppointmentService _service;
    
        public DetailsModel(IAppointmentService service)
        {
            _service = service;
        }
        public Appointment Appointment { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(Guid id)
        {
            Role = HttpContext.Session.GetString("Role");
            var userIdStr = HttpContext.Session.GetString("Account");
            if (string.IsNullOrEmpty(Role) || string.IsNullOrEmpty(userIdStr))
            {
                return RedirectToPage("/Login");
            }
            if (id == null)
            {
                return NotFound();
            }

            var appointment = await _service.GetAppointmentById(id);
            if (appointment == null)
            {
                return NotFound();
            }
            else
            {
                Appointment = appointment;
            }
            return Page();
        }
    }
}
