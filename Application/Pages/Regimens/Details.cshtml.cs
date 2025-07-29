using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repository.Models;
using Service.Interfaces;

namespace Application.Pages.Regimens
{
    public class DetailsModel : PageModel
    {
        private readonly IArvService _arvService;
        private readonly IComboMedicineService _comboMedicineService;

        public DetailsModel(IArvService arvService, IComboMedicineService comboMedicineService)
        {
            _arvService = arvService;
            _comboMedicineService = comboMedicineService;
        }

        public ArvRegimen ArvRegimen { get; set; } = default!;
        public List<ComboMedicine> ComboMedicines { get; set; } = new();

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var arvregimen = await _arvService.GetByIdAsync((Guid)id);
            if (arvregimen == null!)
            {
                return NotFound();
            }
          
            ArvRegimen = arvregimen; 
            ComboMedicines = await _comboMedicineService.GetComboMedicinesByRegimenIdAsync(arvregimen.Id);

            return Page();
        }
    }
}