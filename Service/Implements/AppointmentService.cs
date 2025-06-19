using Repository.Interfaces;
using Repository.Models;
using Service.Interfaces;

namespace Service.Implements;

public class AppointmentService : IAppointmentService
{

    private readonly IGenericRepository<Appointment> _repo;
    
    public AppointmentService(IGenericRepository<Appointment> appointmentRepo)
    {
        _repo = appointmentRepo;
    }
    
    public Task<Appointment> GetAppointmentById(Guid id)
    {
        var appointment = _repo.GetByIdWithIncludes(id, a => a.Doctor, a => a.User);
        if (appointment == null)
        {
            throw new KeyNotFoundException("Appointment not found");
        }
        return Task.FromResult(appointment);
    }

    public async Task<Appointment> CreateAppointmentWithScheduleAsync(Appointment appointment)
    {
        appointment.Id = Guid.NewGuid();
        appointment.Status = "Pending";
        await _repo.CreateAsync(appointment);

        return appointment;
    }

    public async Task<List<Appointment>> GetAppointmentByUserId(Guid userId)
    {
        return await _repo.GetListWithConditionAsync(
            a => a.UserId == userId,
            a => a.Doctor,
            a => a.User
        );
    }

    public async Task<List<Appointment>> GetAllAppointments()
    {
        return await _repo.GetListWithConditionAsync(_ => true,
            a => a.Doctor,
            a => a.User
        );
    }
}