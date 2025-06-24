using Repository.Interfaces;
using Repository.Models;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Implements
{
    public class DoctorService : IDoctorService
    {
        private readonly IGenericRepository<Doctor> _repo;
        public DoctorService(IGenericRepository<Doctor> doctorRepo)
        {
            _repo = doctorRepo;
        }
        public List<Doctor> GetAllDoctors()
        {
            return _repo.GetAll();
        }
    }
}
