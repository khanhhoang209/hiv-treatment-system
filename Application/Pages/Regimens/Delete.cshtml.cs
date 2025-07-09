using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Repository.Models;
using Service.Interfaces;

namespace Application.Pages.Regimens
{
    public class DeleteModel : PageModel
    {
        private readonly IArvService _arvService;

        public DeleteModel(IArvService arvService)
        {
            _arvService = arvService;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var arvregimen = await _arvService.GetByIdAsync((Guid)id);
            if (arvregimen != null!)
            {
                ArvRegimen = arvregimen;
                await _arvService.DeleteAsync((Guid)id);
            }

            return RedirectToPage("./Index");
        }
    }
}