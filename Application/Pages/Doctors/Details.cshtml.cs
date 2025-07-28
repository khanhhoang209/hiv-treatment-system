using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repository.Models;
using Service.Interfaces;

namespace Application.Pages.Doctors
{
    public class DetailsModel : PageModel
    {
        private readonly IDoctorService _doctorService;

        public DetailsModel(IDoctorService doctorService)
        {
            _doctorService = doctorService;
        }

        public Doctor Doctor { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var doctor = await _doctorService.GetDoctorById((Guid)id);
            if (doctor == null)
            {
                return NotFound();
            }
            else
            {
                Doctor = doctor;
            }
            return Page();
        }
    }
}