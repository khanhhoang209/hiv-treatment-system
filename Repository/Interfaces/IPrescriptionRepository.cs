using Repository.Models;

namespace Repository.Interfaces;

public interface IPrescriptionRepository : IGenericRepository<Prescription>
{
    Task<IEnumerable<Prescription>> GetAllWithDetailsAsync();
    Task<Prescription?> GetByIdWithDetailsAsync(Guid id);
    Task<IEnumerable<Prescription>> GetByMedicalRecordIdAsync(Guid medicalRecordId);
    Task<Prescription?> GetWithMedicinesAsync(Guid id);
}