using Repository.Models;

namespace Service.Interfaces;

public interface IAppointmentService
{
    Task<Appointment> GetAppointmentById(Guid id);
    Task<Appointment> CreateAppointmentWithScheduleAsync(Appointment appointment);
    
    Task<List<Appointment>> GetAppointmentByUserId(Guid userId);
    Task<List<Appointment>> GetAllAppointments();
    Task<bool> UpdateAppointmentFields(Appointment appointment);
    Task<List<Appointment>> GetAppointmentByDoctorId(Guid doctorId);
}