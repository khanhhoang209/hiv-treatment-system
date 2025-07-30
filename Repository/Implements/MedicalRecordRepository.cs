using Microsoft.EntityFrameworkCore;
using Repository.Context;
using Repository.Interfaces;
using Repository.Models;

namespace Repository.Implements;

public class MedicalRecordRepository : GenericRepository<MedicalRecord>, IMedicalRecordRepository
{
    public MedicalRecordRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
    
    public async Task<IList<MedicalRecord>> GetMedicalRecordsAsync()
    {
        return await _dbContext.MedicalRecords
            .Include(md => md.Prescription)
            .Include(md => md.TestResults)
            .ToListAsync();
    }
    public async Task<IList<MedicalRecord>> GetMedicalRecordsByUserIdAsync(Guid userId)
    {
        return await _dbContext.MedicalRecords
            .Where(md => md.UserId == userId)
            .Include(md => md.Prescription)
            .Include(md => md.TestResults)
            .ToListAsync();
    }
}