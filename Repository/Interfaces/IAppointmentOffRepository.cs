using Repository.Models;

namespace Repository.Interfaces;

public interface IAppointmentOffRepository : IGenericRepository<Appointment>
{
    Task<Appointment> GetAppointmentById(Guid id);
    Task CreateAsync(Appointment appointment);
    Task<List<Appointment>> GetAppointmentByUserId(Guid userId);
    Task<List<Appointment>> GetAllAppointments();
    Task<bool> UpdateAppointmentFields(Appointment updated);
}