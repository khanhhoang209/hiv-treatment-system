using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Application.Pages.Shared;

public class AuthorizedPageModel : PageModel
{
    protected bool IsAuthenticated => !string.IsNullOrEmpty(HttpContext.Session.GetString("Account"));
    
    protected string? CurrentUserId => HttpContext.Session.GetString("Account");
    
    protected string? CurrentUserRole => HttpContext.Session.GetString("Role");

    public virtual IActionResult CheckAuthentication()
    {
        if (!IsAuthenticated)
        {
            return RedirectToPage("/Login");
        }
        return Page();
    }

    protected bool IsAdmin => CurrentUserRole?.ToLower() == "admin";
    
    protected bool IsDoctor => CurrentUserRole?.ToLower() == "doctor";
    
    protected bool IsUser => CurrentUserRole?.ToLower() == "user";

    protected bool HasPrescriptionAccess => IsAdmin || IsDoctor;
}
