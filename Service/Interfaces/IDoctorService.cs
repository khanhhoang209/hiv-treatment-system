using Repository.Models;

namespace Service.Interfaces;

public interface IDoctorService
{
    List<Doctor> GetAllDoctors();
}