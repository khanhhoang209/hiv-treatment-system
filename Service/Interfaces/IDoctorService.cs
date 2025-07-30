using Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface IDoctorService
    {
        List<Doctor> GetAllDoctors();
        Task<Doctor> GetDoctor(Guid id);
        Task<IList<Doctor>> GetDoctors();
        Task<Doctor> AddDoctor(Doctor doctor);
        Task<Doctor> UpdateDoctor(Doctor doctor);
        Task<bool> DeleteDoctor(Doctor doctor);
        Task<Doctor?> GetDoctorById(Guid id);
        Task<Doctor?> GetDoctorByUserIdAsync(Guid id);
    }
}