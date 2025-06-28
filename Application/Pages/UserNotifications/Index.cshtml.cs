using Application.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.SignalR;
using Repository.Constants;
using Service.DTOs;
using Service.Interfaces;

namespace Application.Pages.UserNotifications
{
    public class IndexModel : PageModel
    {
        private readonly INotificationService _notificationService;
        
        public IndexModel(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        public IList<UserNotificationDto> UserNotification { get;set; } = [];

        public async Task<IActionResult> OnGetAsync()
        {
            if (!HttpContext.HasRole(Roles.User))
            {
                return RedirectToPage("/AccessDenied");
            }
            
            var userId = HttpContext.GetUserId();
            UserNotification = await _notificationService.GetUserNotificationsByTypeAsync(userId, [NotificationType.MedicationTime]);
            return Page();
        }
    }
}
