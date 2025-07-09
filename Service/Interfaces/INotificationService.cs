using Repository.Constants;
using Service.DTOs;

namespace Service.Interfaces;

public interface INotificationService
{
    Task CreateMedicationNotificationsAsync(MedicationTime currentMedicationTime);

    Task<List<UserNotificationDto>> GetUserNotificationsByTypeAsync(
        Guid userId,
        NotificationType[] notificationTypes
        );
}