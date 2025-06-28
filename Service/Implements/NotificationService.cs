using Microsoft.EntityFrameworkCore;
using Repository.Constants;
using Repository.Extensions;
using Repository.Interfaces;
using Repository.Models;
using Service.DTOs;
using Service.Interfaces;

namespace Service.Implements;

public class NotificationService : INotificationService
{
    private readonly IUnitOfWork _unitOfWork;

    public NotificationService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    
    public async Task CreateMedicationNotificationsAsync(MedicationTime currentMedicationTime)
    {
        var timeValue = (int)currentMedicationTime;

        var prescriptions = await _unitOfWork.PrescriptionRepository
            .Query()
            .Where(p => p.PrescriptionMedicines.Any(pm => (pm.SumOfMedicationTime & timeValue) == timeValue))
            .Include(p => p.MedicalRecord)
            .Include(p => p.PrescriptionMedicines)
                .ThenInclude(pm => pm.Medicine)
            .ToListAsync();
        
        if (prescriptions.Count == 0)
        {
            return;
        }
        
        var newNotifications = new List<Notification>();
        foreach (var prescription in prescriptions)
        {
            var notification = BuildNotification(prescription, currentMedicationTime);
            
            newNotifications.Add(notification);
        }
        
        await _unitOfWork.NotificationRepository.CreateAsync(newNotifications);
        await _unitOfWork.SaveChangesAsync();
    }
    
    public async Task<List<UserNotificationDto>> GetUserNotificationsByTypeAsync(
        Guid userId,
        NotificationType[] notificationTypes)
    {
        var userNotifications = await _unitOfWork.UserNotificationRepository
            .Query()
            .AsNoTracking()
            .Include(un => un.Notification)
            .Where(un =>
                un.UserId == userId &&
                notificationTypes.Contains(un.Notification.NotificationType))
            .Select(un => new UserNotificationDto
            {
                NotificationId   = un.NotificationId,
                UserId           = un.UserId,
                IsRead           = un.IsRead,
                DeliveredAt      = un.DeliveredAt,
                NotificationType = un.Notification.NotificationType,
                Title            = un.Notification.Title,
                Message          = un.Notification.Message,
            })
            .ToListAsync();

        return userNotifications;
    }
    
    private Notification BuildNotification(Prescription prescription, MedicationTime forTime)
    {
        var timeValue = (int)forTime;
        var lines = prescription.PrescriptionMedicines
            .Where(pm => (pm.SumOfMedicationTime & timeValue) == timeValue)
            .Select(pm => $"- {pm.Medicine.Name}: liều {pm.Dosage}, hướng dẫn: {pm.Instructions}")
            .ToList();
        
        foreach (var pm in prescription.PrescriptionMedicines)
        {
            pm.Quantity -= pm.Dosage;
        }
        
        return new Notification
        {
            Title           = $"Nhắc nhở uống thuốc buổi {forTime.GetDisplayName()}",
            Message         = string.Join(Environment.NewLine, lines),
            CreatedAt       = DateTimeOffset.Now,
            NotificationType= NotificationType.MedicationTime,
            Payload         = "OKOKOK",
            UserNotifications = new List<UserNotification> {
                new()
                {
                    UserId      = prescription.MedicalRecord.UserId,
                    IsRead      = false,
                    ReadAt      = null,
                    DeliveredAt = DateTimeOffset.Now
                }
            }
        };
    }
}