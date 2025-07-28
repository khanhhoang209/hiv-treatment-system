using Microsoft.AspNetCore.Mvc.RazorPages;
using Repository.Models;
using Service.Interfaces;

namespace Application.Pages.Doctors
{
    public class IndexModel : PageModel
    {
        private readonly IDoctorService _doctorService;

        public IndexModel(IDoctorService doctorService)
        {
            _doctorService = doctorService;
        }

        public IList<Doctor> Doctor { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Doctor = await _doctorService.GetDoctors();
        }
    }
}