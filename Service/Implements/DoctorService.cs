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
        private readonly IUnitOfWork _unitOfWork;
        public DoctorService(IGenericRepository<Doctor> doctorRepo, IUnitOfWork unitOfWork)
        {
            _repo = doctorRepo;
            _unitOfWork = unitOfWork;
        }
        public List<Doctor> GetAllDoctors()
        {
            return _repo.GetAll();
        }

        public async Task<Doctor> GetDoctor(Guid id)
        {
            return await _repo.GetByIdAsync(id);
        }

        public async Task<IList<Doctor>> GetDoctors()
        {
            return await _unitOfWork.DoctorRepository.GetDoctorsAsync();
        }

        public async Task<Doctor> AddDoctor(Doctor doctor)
        {
            await _unitOfWork.DoctorRepository.CreateAsync(doctor);
            return doctor;
        }

        public async Task<Doctor> UpdateDoctor(Doctor doctor)
        {
            await _unitOfWork.DoctorRepository.UpdateAsync(doctor);
            return doctor;
        }

        public async Task<bool> DeleteDoctor(Doctor doctor)
        {
            var availabeDoctor = await _unitOfWork.DoctorRepository.GetByIdAsync(doctor.Id);
            if (availabeDoctor != null)
            {
                return await _unitOfWork.DoctorRepository.RemoveAsync(availabeDoctor);
            }
            return false;
        }

        public async Task<Doctor?> GetDoctorById(Guid id)
        {
            return await _unitOfWork.DoctorRepository.GetDoctorByIdAsync(id)!;
        }
    }
}