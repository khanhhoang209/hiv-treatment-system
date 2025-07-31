using Repository.Interfaces;
using Repository.Models;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Repository.Implements;

namespace Service.Implements
{
    public class MedicalRecordService : IMedicalRecordService
    {
        private readonly IGenericRepository<MedicalRecord> _repo;
        private readonly IMedicalRecordRepository _medicalRecordRepository;

        public MedicalRecordService(IGenericRepository<MedicalRecord> medicalRecordRepo,
            IMedicalRecordRepository medicalRecordRepository)
        {
            _repo = medicalRecordRepo;
            _medicalRecordRepository = medicalRecordRepository;
        }

        public async Task<MedicalRecord> CreateMedicalRecord(MedicalRecord record)
        {
            record.Id = Guid.NewGuid();
            await _repo.CreateAsync(record);

            return record;
        }

        public async Task<List<MedicalRecord>> GetAllMedicalRecords()
        {
            return await _repo.Query().Include(mr => mr.User).Include(mr => mr.Doctor).ToListAsync();
        }

        public async Task<List<MedicalRecord>> GetMedicalRecordsByDoctorId(Guid userId)
        {
            return await _repo.GetListAsync(a => a.DoctorId == userId);
        }

        public async Task<MedicalRecord> GetMedicalRecordDetail(Guid recordId)
        {
            return await _repo.GetByIdAsync(recordId);
        }

        public async Task<List<MedicalRecord>> GetMedicalRecordsByUserId(Guid userId)
        {
            return await _repo.GetListAsync(a => a.UserId == userId);
        }

        public async Task<bool> UpdateMedicalRecord(MedicalRecord record)
        {
            return await _repo.UpdateAsync(record);
        }

        public async Task<IList<MedicalRecord>> GetMedicalRecordsAsync()
        {
            return await _medicalRecordRepository.GetMedicalRecordsAsync();
        }

        public async Task<IList<MedicalRecord>> GetMedicalRecordsByUserIdAsync(Guid userId)
        {
            return await _medicalRecordRepository.GetMedicalRecordsByUserIdAsync(userId);
        }
    }
}
