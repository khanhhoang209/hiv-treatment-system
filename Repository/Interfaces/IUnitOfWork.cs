namespace Repository.Interfaces;

public interface IUnitOfWork
{
    IArvRepository ArvRepository { get; }
    INotificationRepository NotificationRepository { get; }
    IPrescriptionRepository PrescriptionRepository { get; }
    IPrescriptionMedicineRepository PrescriptionMedicineRepository { get; }
    IUserNotificationRepository UserNotificationRepository { get; }
    Task<bool> SaveChangesAsync();
    IDoctorRepository DoctorRepository { get; }
    IEmployeeRepository EmployeeRepository { get; }
    IClinicRepository ClinicRepository { get; }
}