using Repository.Models;

namespace Service.Interfaces;

public interface IDoctorService
{
    List<Doctor> GetAllDoctors();
    Doctor? GetDoctorById(Guid id);
}