using Repository.Models;

namespace Service.Interfaces;

public interface IStaffService
{
    Task<List<Staff>> GetStaffs();
    Task<Staff?> GetStaffByIdAsync(Guid id);
    Task<Staff> CreateAsync(Staff staff);
    Task<Staff> UpdateAsync(Staff staff);
    Task<bool> DeleteAsync(Staff staff);
}