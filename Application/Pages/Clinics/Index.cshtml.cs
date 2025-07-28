using Microsoft.AspNetCore.Mvc.RazorPages;
using Repository.Models;
using Service.Interfaces;

namespace Application.Pages.Clinics
{
    public class IndexModel : PageModel
    {
        private readonly IClinicService _clinicService;

        public IndexModel(IClinicService clinicService)
        {
            _clinicService = clinicService;
        }

        public IList<Clinic> Clinic { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Clinic = await _clinicService.GetClinics();
        }
    }
}