namespace Repository.Interfaces;

public interface IUnitOfWork
{
    IArvRepository ArvRepository { get; }
    INotificationRepository NotificationRepository { get; }
    IPrescriptionRepository PrescriptionRepository { get; }
    IUserNotificationRepository UserNotificationRepository { get; }
    Task<bool> SaveChangesAsync();
}