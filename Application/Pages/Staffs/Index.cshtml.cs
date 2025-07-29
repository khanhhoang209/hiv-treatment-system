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
    public class IndexModel : PageModel
    {
        private readonly IStaffService _staffService;

        public IndexModel(IStaffService staffService)
        {
            _staffService = staffService;
        }

        public IList<Staff> Staff { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Staff = await _staffService.GetStaffs();
        }
    }
}