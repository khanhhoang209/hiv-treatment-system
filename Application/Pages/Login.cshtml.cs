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
            return RedirectToPage("/Login");
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
            ModelState.AddModelError(string.Empty, "You do not have permission to do this function!");
            return Page();
        }

        if (user.Password != User.Password)
        {
            ModelState.AddModelError("User.Password", "Mật khẩu không đúng.");
            return Page();
        }
        
        var redirectUrl = "/Index";
        if (user.Role.Name.ToLower() == Roles.Admin.ToLower())
        {
            redirectUrl = "/Dashboard/Index";
        }
        else if (user.Role.Name.ToLower() == Roles.Doctor.ToLower())
        {
            redirectUrl = "/Appointments/Index";
        }
        
        HttpContext.Session.SetString("Role", user.Role.Name);
        HttpContext.Session.SetString("Account", user.Id.ToString());
        
        return RedirectToPage(redirectUrl);
    }
}