using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repository.Models;
using Service.Interfaces;

namespace Application.Pages.Regimens
{
    public class DetailsModel : PageModel
    {
        private readonly IArvService _arvService;

        public DetailsModel(IArvService arvService)
        {
            _arvService = arvService;
        }

        public ArvRegimen ArvRegimen { get; set; } = default!;

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
            else
            {
                ArvRegimen = arvregimen;
            }
            return Page();
        }
    }
}