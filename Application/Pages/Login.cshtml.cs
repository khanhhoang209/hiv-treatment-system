using Application.Extensions;
using Microsoft.AspNetCore.Mvc;
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
            if (HttpContext.HasRole([Roles.Admin]))
            {
                return RedirectToPage("/Dashboard/Index");
            }
            else if (HttpContext.HasRole([Roles.Doctor, Roles.User]))
            {
                return RedirectToPage("/Home");
            }
        }
        return Page();
    }
    
    [BindProperty]
    public ApplicationUser User { get; set; } = default!;
    
    public async Task<IActionResult> OnPostAsync()
    {
        var loginId = HttpContext.Session.GetString("Account");
        if (!string.IsNullOrEmpty(loginId))
        {
            return RedirectToPage("/Login");
        }

        var user = _userService.GetAccountByUserName(User.Username);

        if (user == null)
        {
            ModelState.AddModelError(string.Empty, "Tài khoản không tồn tại!");
            return Page();
        }

        if (user.Password != User.Password)
        {
            ModelState.AddModelError(string.Empty, "Mật khẩu không đúng!");
            return Page();
        }

        if (user.Status != "Active")
        {
            ModelState.AddModelError(string.Empty, "Tài khoản đã bị khóa!");
            return Page();
        }

        // Set session data
        HttpContext.Session.SetString("Account", user.Id.ToString());
        HttpContext.Session.SetString("Username", user.Username);
        HttpContext.Session.SetString("Email", user.Email);
        HttpContext.Session.SetString("Role", user.Role.Name);

        // Redirect based on role
        if (user.Role.Name == Roles.Admin)
        {
            return RedirectToPage("/Dashboard/Index");
        }
        else if (user.Role.Name == Roles.Doctor)
        {
            return RedirectToPage("/MedicalRecords/Index");
        }
        else if (user.Role.Name == Roles.Staff)
        {
            return RedirectToPage("/Appointments/Index");
        }
        else
        {
            return RedirectToPage("/Home");
        }
    }

    // Logout action
    public async Task<IActionResult> OnGetLogoutAsync()
    {
        // Clear all session data
        HttpContext.Session.Clear();
        
        // Optionally add a success message
        TempData["Message"] = "Bạn đã đăng xuất thành công!";
        
        return RedirectToPage("/Login");
    }
}