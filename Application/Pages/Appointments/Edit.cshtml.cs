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
using Service.Interfaces;

namespace Application.Pages.Appointments
{
    public class EditModel : PageModel
    {
        private readonly IAppointmentService _service;

        public EditModel(IAppointmentService service)
        {
            _service = service;
        }

        [BindProperty]
        public Appointment Appointment { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            var role = HttpContext.Session.GetString("Role");
            var userIdStr = HttpContext.Session.GetString("Account");
            if (string.IsNullOrEmpty(role) || string.IsNullOrEmpty(userIdStr))
            {
                return RedirectToPage("/Login");
            }
            if (role == "User")
            {
                return RedirectToPage("/Appointments/Index");
            }
            if (id == null)
            {
                return NotFound();
            }

            var appointment =  await _service.GetAppointmentById(id.Value);
            if (appointment == null)
            {
                return NotFound();
            }
            Appointment = appointment;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            ModelState.Remove("Appointment.Doctor");
            ModelState.Remove("Appointment.User");
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                await _service.UpdateAppointmentFields(Appointment);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (AppointmentExists(Appointment.Id) == null)
                {
                    return RedirectToPage("/Error");
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private Task<Appointment> AppointmentExists(Guid id)
        {
            return _service.GetAppointmentById(id);
        }
    }
}
