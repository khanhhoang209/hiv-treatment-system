using Repository.Models;

namespace Repository.Interfaces;

public interface IDoctorRepository : IGenericRepository<Doctor>
{
    Task<IList<Doctor>> GetDoctorsAsync();
    Task<Doctor?> GetDoctorByIdAsync(Guid id);

}