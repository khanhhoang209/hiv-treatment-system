using Service.DTOs;

namespace Service.Interfaces;

public interface IPrescriptionService
{
    Task<IEnumerable<PrescriptionDto>> GetAllPrescriptionsAsync();
    Task<PrescriptionDto?> GetPrescriptionByIdAsync(Guid id);
    Task<IEnumerable<PrescriptionDto>> GetPrescriptionsByMedicalRecordIdAsync(Guid medicalRecordId);
    Task<PrescriptionDto> CreatePrescriptionAsync(CreatePrescriptionDto createDto);
    Task<PrescriptionDto> UpdatePrescriptionAsync(UpdatePrescriptionDto updateDto);
    Task<bool> DeletePrescriptionAsync(Guid id);
    Task<PrescriptionDto?> GetPrescriptionWithMedicinesAsync(Guid id);
    Task<bool> GetPrescriptionByMedicalRecordId(Guid medicalRecordId);
    
}
