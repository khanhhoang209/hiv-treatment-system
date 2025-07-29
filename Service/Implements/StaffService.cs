using Microsoft.EntityFrameworkCore;
using Repository.Interfaces;
using Repository.Models;
using Service.Interfaces;

namespace Service.Implements;

public class StaffService : IStaffService
{
    private readonly IGenericRepository<Staff> _repo;

    public StaffService(IGenericRepository<Staff> repo)
    {
        _repo = repo;
    }

    public async Task<List<Staff>> GetStaffs()
    {
        return await _repo.Query()
            .Include(s => s.Employee)
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<Staff?> GetStaffByIdAsync(Guid id)
    {
        return await _repo.Query()
            .Include(s => s.Employee)
            .AsNoTracking()
            .FirstOrDefaultAsync(s => s.Id == id);
    }

    public async Task<Staff> CreateAsync(Staff staff)
    {
        await _repo.CreateAsync(staff);
        return staff;
    }

    public async Task<Staff> UpdateAsync(Staff staff)
    {
        await _repo.UpdateAsync(staff);
        return staff;
    }

    public async Task<bool> DeleteAsync(Staff staff)
    {
        await _repo.RemoveAsync(staff);
        return true;
    }
}