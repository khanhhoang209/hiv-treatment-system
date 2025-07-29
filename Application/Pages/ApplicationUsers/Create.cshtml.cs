using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Repository.Context;
using Repository.Models;
using Service.Interfaces;

namespace Application.Pages.ApplicationUsers
{
    public class CreateModel : PageModel
    {
        private readonly IUserService _userService;
        private readonly IRoleService _roleService;

        public CreateModel(IUserService userService, IRoleService roleService)
        {
            _userService = userService;
            _roleService = roleService;
        }

        public IActionResult OnGet()
        {
            ViewData["RoleId"] = new SelectList(_roleService.GetRoles(), "Id", "Name");
            return Page();
        }

        [BindProperty]
        public ApplicationUser ApplicationUser { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            ApplicationUser.Status = "Active";
            await _userService.CreateUser(ApplicationUser);

            return RedirectToPage("./Index");
        }
    }
}