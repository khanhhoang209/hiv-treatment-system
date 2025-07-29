using Microsoft.EntityFrameworkCore;
using Repository.Context;
using Repository.Interfaces;
using Repository.Models;

namespace Repository.Implements;

public class PrescriptionRepository : GenericRepository<Prescription>, IPrescriptionRepository
{
    public PrescriptionRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<IEnumerable<Prescription>> GetAllWithDetailsAsync()
    {
        return await _dbContext.Set<Prescription>()
            .Include(p => p.MedicalRecord)
                .ThenInclude(mr => mr.User)
            .Include(p => p.MedicalRecord)
                .ThenInclude(mr => mr.Doctor)
                    .ThenInclude(d => d.Employee)
            .Include(p => p.PrescriptionMedicines)
                .ThenInclude(pm => pm.Medicine)
            .OrderByDescending(p => p.PrescriptionDate)
            .ToListAsync();
    }

    public async Task<Prescription?> GetByIdWithDetailsAsync(Guid id)
    {
        return await _dbContext.Set<Prescription>()
            .Include(p => p.MedicalRecord)
                .ThenInclude(mr => mr.User)
            .Include(p => p.MedicalRecord)
                .ThenInclude(mr => mr.Doctor)
                    .ThenInclude(d => d.Employee)
            .Include(p => p.PrescriptionMedicines)
                .ThenInclude(pm => pm.Medicine)
            .FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task<IEnumerable<Prescription>> GetByMedicalRecordIdAsync(Guid medicalRecordId)
    {
        return await _dbContext.Set<Prescription>()
            .Include(p => p.PrescriptionMedicines)
                .ThenInclude(pm => pm.Medicine)
            .Where(p => p.MedicalRecordId == medicalRecordId)
            .OrderByDescending(p => p.PrescriptionDate)
            .ToListAsync();
    }

    public async Task<Prescription?> GetWithMedicinesAsync(Guid id)
    {
        return await _dbContext.Set<Prescription>()
            .Include(p => p.PrescriptionMedicines)
                .ThenInclude(pm => pm.Medicine)
            .FirstOrDefaultAsync(p => p.Id == id);
    }
}