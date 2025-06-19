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
    public class IndexModel : PageModel
    {
        public string? Role { get; set; }
        private readonly Repository.Context.ApplicationDbContext _context;
        private readonly IAppointmentService _service;
        public IndexModel(Repository.Context.ApplicationDbContext context, IAppointmentService service)
        {
            _context = context;
            _service = service;
        }

        public IList<Appointment> Appointment { get;set; } = default!;

        public async Task<IActionResult> OnGetAsync()
        {
            Role = HttpContext.Session.GetString("Role");
            var userIdStr = HttpContext.Session.GetString("Account");
            if (string.IsNullOrEmpty(Role) || string.IsNullOrEmpty(userIdStr))
            {
                return RedirectToPage("/Login");
            }

            if (Role != "Admin" && Guid.TryParse(userIdStr, out var userId))
            {
               Appointment = await _service.GetAppointmentByUserId(userId);
            }
            else
            {
                Appointment = await _service.GetAllAppointments();
            }

            return Page();
        }
    }
}
