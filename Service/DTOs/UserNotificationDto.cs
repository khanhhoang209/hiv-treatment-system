using System.ComponentModel.DataAnnotations;
using Repository.Constants;

namespace Service.DTOs;

public class UserNotificationDto
{
    [Display(Name = "Mã thông báo")]
    public Guid NotificationId { get; set; }

    [Display(Name = "Mã người dùng")]
    public Guid UserId { get; set; }

    [Display(Name = "Đã đọc")]
    public bool IsRead { get; set; }

    [Display(Name = "Thời gian gửi")]
    public DateTimeOffset? DeliveredAt { get; set; }

    [Display(Name = "Loại thông báo")]
    public NotificationType NotificationType { get; set; }

    [Display(Name = "Tiêu đề")]
    public string Title { get; set; } = null!;

    [Display(Name = "Nội dung")]
    public string Message { get; set; } = null!;
}