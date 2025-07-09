using Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface IDoctorClinicRepository
    {
        Task<List<DoctorClinic>> GetAllAsync();
        Task AddAsync(DoctorClinic doctorClinic);
    }
}
