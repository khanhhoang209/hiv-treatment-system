using Microsoft.IdentityModel.Tokens;

namespace Application.Extensions;

public static class AuthExtensions
{
    public static bool HasRole(this HttpContext httpContext, params string[] allowedRoles)
    {
        var role = httpContext.Session?.GetString("Role");
        return !role.IsNullOrEmpty() && allowedRoles.Contains(role);
    }

    public static Guid GetUserId(this HttpContext httpContext)
    {
        return httpContext.Session.GetString("Account") == null ? Guid.Empty : Guid.Parse(httpContext.Session.GetString("Account")!);
    }
}