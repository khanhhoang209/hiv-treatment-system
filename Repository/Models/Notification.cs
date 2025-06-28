using System.ComponentModel.DataAnnotations.Schema;
using Repository.Constants;

namespace Repository.Models
{
    [Table("Notification")]
    public class Notification
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = null!;
        public string Message { get; set; } = null!;
        public string Payload { get; set; } = null!;
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset ExpiresAt { get; set; }
        public NotificationType NotificationType { get; set; }
        public ICollection<UserNotification> UserNotifications { get; set; } = null!;
    }
}