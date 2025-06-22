using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repository.Models;
using Service.Interfaces;

namespace Application.Pages.Regimens
{
    public class CreateModel : PageModel
    {
        private readonly IArvService _arvService;

        public CreateModel(IArvService arvService)
        {
            _arvService = arvService;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public ArvRegimen ArvRegimen { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            await _arvService.CreateAsync(ArvRegimen);

            return RedirectToPage("./Index");
        }
    }
}