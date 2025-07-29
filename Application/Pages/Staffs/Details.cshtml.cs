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

namespace Application.Pages.Staffs
{
    public class DetailsModel : PageModel
    {
        private readonly IStaffService _staffService;

        public DetailsModel(IStaffService staffService)
        {
            _staffService = staffService;
        }

        public Staff Staff { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var staff = await _staffService.GetStaffByIdAsync(id.Value);
            if (staff == null)
            {
                return NotFound();
            }
            else
            {
                Staff = staff;
            }
            return Page();
        }
    }
}