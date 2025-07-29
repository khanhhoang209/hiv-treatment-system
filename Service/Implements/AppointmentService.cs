using Repository.Interfaces;
using Repository.Models;
using Service.Interfaces;

namespace Service.Implements;

public class AppointmentService : IAppointmentService
{

    private readonly IUnitOfWork _unitOfWork;
    
    public AppointmentService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    
    public Task<Appointment> GetAppointmentById(Guid id)
    {
        return _unitOfWork.AppointmentOffRepository.GetAppointmentById(id);
    }

    public async Task<Appointment> CreateAppointmentWithScheduleAsync(Appointment appointment)
    {
        await _unitOfWork.AppointmentOffRepository.CreateAsync(appointment);
        return appointment;
    }

    public async Task<List<Appointment>> GetAppointmentByUserId(Guid userId)
    {
        return await _unitOfWork.AppointmentOffRepository.GetAppointmentByUserId(userId);
    }

    public async Task<List<Appointment>> GetAllAppointments()
    {
        return await _unitOfWork.AppointmentOffRepository.GetAllAppointments();
    }
    public async Task<bool> UpdateAppointmentFields(Appointment updated)
    {   
        return await _unitOfWork.AppointmentOffRepository.UpdateAppointmentFields(updated);
    }
    public async Task<List<Appointment>> GetAppointmentByDoctorId(Guid doctorId)
    {
        return await _unitOfWork.AppointmentOffRepository.GetAppointmentByDoctorId(doctorId);
    }
}