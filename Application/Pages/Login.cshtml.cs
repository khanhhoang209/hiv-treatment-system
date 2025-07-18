﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repository.Constants;
using Repository.Models;
using Service.Interfaces;

namespace Application.Pages;

public class LoginModel : PageModel
{
    private IUserService _userService;
    
    public LoginModel(IUserService userService)
    {
        _userService = userService;
    }
    
    public async Task<IActionResult> OnGetAsync()
    {
        var loginId = HttpContext.Session.GetString("Account");
        if (!string.IsNullOrEmpty(loginId))
        {
            return RedirectToPage("/Appointments");
        }
        return Page();
    }
    
    [BindProperty]
    public ApplicationUser User { get; set; } = default!;
    
    public async Task<IActionResult> OnPostAsync()
    {
        // var loginId = HttpContext.Session.GetString("Account");
        // if (!string.IsNullOrEmpty(loginId))
        // {
        //     return RedirectToPage("/Appointments/Create");
        // }

        var user = _userService.GetAccountByUserName(User.Username);

        if (user == null)
        {
            ModelState.AddModelError(string.Empty, "You do not have permission to do this function!");
            return Page();
        }

        if (user.Password != User.Password)
        {
            ModelState.AddModelError("User.Password", "Mật khẩu không đúng.");
            return Page();
        }

        if (user.RoleId.ToString() == "d9b8e0d2-8c17-4f84-9a9e-1b1b3d9c58fd") // Admin
        {
            HttpContext.Session.SetString("Role", Roles.Admin);
            HttpContext.Session.SetString("Account", user.Id.ToString());
            return RedirectToPage("/Appointments/Index");
        }

        if (user.RoleId.ToString() == "88af217f-2fb8-48b6-8fdf-a1e6f36d4647") // Doctor
        {
            HttpContext.Session.SetString("Role", "Doctor");
            HttpContext.Session.SetString("Account", user.Id.ToString());
            return RedirectToPage("/Appointments/Index");
        }

        
        HttpContext.Session.SetString("Role", "User");
        HttpContext.Session.SetString("Account", user.Id.ToString());

        return RedirectToPage("/Appointments/Index");
    }
}