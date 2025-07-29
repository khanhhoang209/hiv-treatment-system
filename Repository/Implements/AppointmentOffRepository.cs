using Microsoft.EntityFrameworkCore;
using Repository.Context;
using Repository.Interfaces;
using Repository.Models;

namespace Repository.Implements;

public class AppointmentOffRepository : GenericRepository<Appointment>, IAppointmentOffRepository
{
    public AppointmentOffRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<Appointment> GetAppointmentById(Guid id)
    {
        
        var appointmnet = await _dbContext.Appointments.Include(a => a.Doctor)
            .Include(a=> a.User)
            .FirstOrDefaultAsync(a => a.Id == id);
        return appointmnet!;
    }
    
    public async Task CreateAsync(Appointment appointment)
    {
        appointment.Id = Guid.NewGuid();
        await _dbContext.Appointments.AddAsync(appointment);
        await _dbContext.SaveChangesAsync();
    }
    public async Task<List<Appointment>> GetAppointmentByUserId(Guid userId)
    {
        return await _dbContext.Appointments
            .Include(a => a.Doctor)
            .Include(a => a.User)
            .Where(a => a.UserId == userId)
            .OrderByDescending(a => a.AppointmentDate)
            .ToListAsync();
    }
    public async Task<List<Appointment>> GetAllAppointments()
    {
        return await _dbContext.Appointments
            .Include(a => a.Doctor)
            .Include(a => a.User)
            .OrderByDescending(a => a.AppointmentDate)
            .ToListAsync();
    }
    public async Task<bool> UpdateAppointmentFields(Appointment updated)
    {
        var appointment = await _dbContext.Appointments.FindAsync(updated.Id);
        if (appointment == null)
            throw new KeyNotFoundException("Appointment not found");

        appointment.AppointmentDate = updated.AppointmentDate;
        appointment.Status = updated.Status;

        _dbContext.Appointments.Update(appointment);
        return await _dbContext.SaveChangesAsync() > 0;
    }
    public async Task<List<Appointment>> GetAppointmentByDoctorId(Guid doctorId)
    {
        return await _dbContext.Appointments
            .Include(a => a.Doctor)
            .Include(a => a.User)
            .Where(a => a.DoctorId == doctorId)
            .OrderByDescending(a => a.AppointmentDate)
            .ToListAsync();
    }
    
}