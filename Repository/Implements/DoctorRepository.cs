using Microsoft.EntityFrameworkCore;
using Repository.Context;
using Repository.Interfaces;
using Repository.Models;

namespace Repository.Implements;

public class DoctorRepository : GenericRepository<Doctor>, IDoctorRepository
{
    public DoctorRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<IList<Doctor>> GetDoctorsAsync()
    {
        return await _dbContext.Doctors
            .Include(d => d.Employee)
            .ToListAsync();
    }

    public Task<Doctor?> GetDoctorByIdAsync(Guid id)
    {
        return _dbContext.Doctors
            .Include(d => d.Employee)
            .FirstOrDefaultAsync(d => d.Id == id);
    }
}