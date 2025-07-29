namespace Repository.Interfaces;

public interface IUnitOfWork
{
    IArvRepository ArvRepository { get; }
    INotificationRepository NotificationRepository { get; }
    IPrescriptionRepository PrescriptionRepository { get; }
    IPrescriptionMedicineRepository PrescriptionMedicineRepository { get; }
    IUserNotificationRepository UserNotificationRepository { get; }
    IAppointmentOffRepository AppointmentOffRepository { get; }
    IComboMedicineRepository ComboMedicineRepository { get; }
    IMedicineRepository MedicineRepository { get; }
    Task<bool> SaveChangesAsync();
    IDoctorRepository DoctorRepository { get; }
    IEmployeeRepository EmployeeRepository { get; }
    IClinicRepository ClinicRepository { get; }
}