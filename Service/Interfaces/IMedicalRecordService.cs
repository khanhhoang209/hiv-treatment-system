using Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface IMedicalRecordService
    {
        Task<MedicalRecord> CreateMedicalRecord(MedicalRecord record);
        Task<bool> UpdateMedicalRecord(MedicalRecord record);
        Task<List<MedicalRecord>> GetAllMedicalRecords();
        Task<List<MedicalRecord>> GetMedicalRecordsByDoctorId(Guid userId);
        Task<List<MedicalRecord>> GetMedicalRecordsByUserId(Guid userId);
        Task<MedicalRecord> GetMedicalRecordDetail(Guid recordId);
    }
}
