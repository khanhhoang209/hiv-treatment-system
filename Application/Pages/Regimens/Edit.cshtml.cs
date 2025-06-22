using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Repository.Models;
using Service.Interfaces;

namespace Application.Pages.Regimens
{
    public class EditModel : PageModel
    {
        private readonly IArvService _arvService;

        public EditModel(IArvService arvService)
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

            var arvregimen =  await _arvService.GetByIdAsync((Guid)id);
            if (arvregimen == null!)
            {
                return NotFound();
            }
            ArvRegimen = arvregimen;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _arvService.UpdateAsync(ArvRegimen);
            return RedirectToPage("./Index");
        }

        private bool ArvRegimenExists(Guid id)
        {
            return _arvService.GetByIdAsync(id) != null!;
        }
    }
}