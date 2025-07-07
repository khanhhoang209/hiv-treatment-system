using System.ComponentModel.DataAnnotations.Schema;

namespace Repository.Models
{
    [Table("UserNotification")]
    public class UserNotification
    {
        public Guid NotificationId { get; set; }
        public Guid UserId { get; set; }
        public bool IsRead { get; set; }
        public DateTimeOffset? ReadAt { get; set; }
        public DateTimeOffset? DeliveredAt { get; set; }
        public Notification Notification { get; set; } = null!;
        public ApplicationUser User { get; set; } = null!;
    }
}