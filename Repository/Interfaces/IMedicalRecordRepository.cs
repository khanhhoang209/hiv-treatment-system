using Repository.Models;

namespace Repository.Interfaces;

public interface IMedicalRecordRepository : IGenericRepository<MedicalRecord>
{
    Task<IList<MedicalRecord>> GetMedicalRecordsAsync();
    Task<IList<MedicalRecord>> GetMedicalRecordsByUserIdAsync(Guid userId);
}