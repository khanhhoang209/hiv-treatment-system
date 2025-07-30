using AutoMapper;
using Repository.Interfaces;
using Repository.Models;
using Service.DTOs;
using Service.Interfaces;

namespace Service.Implements;

public class PrescriptionService : IPrescriptionService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public PrescriptionService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<IEnumerable<PrescriptionDto>> GetAllPrescriptionsAsync()
    {
        var prescriptions = await _unitOfWork.PrescriptionRepository.GetAllWithDetailsAsync();
        return _mapper.Map<IEnumerable<PrescriptionDto>>(prescriptions);
    }

    public async Task<PrescriptionDto?> GetPrescriptionByIdAsync(Guid id)
    {
        var prescription = await _unitOfWork.PrescriptionRepository.GetByIdWithDetailsAsync(id);
        return prescription != null ? _mapper.Map<PrescriptionDto>(prescription) : null;
    }

    public async Task<IEnumerable<PrescriptionDto>> GetPrescriptionsByMedicalRecordIdAsync(Guid medicalRecordId)
    {
        var prescriptions = await _unitOfWork.PrescriptionRepository.GetByMedicalRecordIdAsync(medicalRecordId);
        return _mapper.Map<IEnumerable<PrescriptionDto>>(prescriptions);
    }

    public async Task<PrescriptionDto?> GetPrescriptionWithMedicinesAsync(Guid id)
    {
        var prescription = await _unitOfWork.PrescriptionRepository.GetWithMedicinesAsync(id);
        return prescription != null ? _mapper.Map<PrescriptionDto>(prescription) : null;
    }

    public async Task<PrescriptionDto> CreatePrescriptionAsync(CreatePrescriptionDto createDto)
    {
        var prescription = new Prescription
        {
            Id = Guid.NewGuid(),
            PrescriptionDate = createDto.PrescriptionDate,
            Notes = createDto.Notes,
            MedicalRecordId = createDto.MedicalRecordId,
            PrescriptionMedicines = new List<PrescriptionMedicine>()
        };

        // Add medicines if provided
        foreach (var medicineDto in createDto.Medicines)
        {
            var prescriptionMedicine = new PrescriptionMedicine
            {
                PrescriptionId = prescription.Id,
                MedicineId = medicineDto.MedicineId,
                Quantity = medicineDto.Quantity,
                Dosage = medicineDto.Dosage,
                Instructions = medicineDto.Instructions,
                SumOfMedicationTime = medicineDto.SumOfMedicationTime,
                BoughtPrice = medicineDto.BoughtPrice
            };
            prescription.PrescriptionMedicines.Add(prescriptionMedicine);
        }

        await _unitOfWork.PrescriptionRepository.CreateAsync(prescription);
        await _unitOfWork.SaveChangesAsync();

        return await GetPrescriptionByIdAsync(prescription.Id) ?? throw new InvalidOperationException("Failed to create prescription");
    }

    public async Task<PrescriptionDto> UpdatePrescriptionAsync(UpdatePrescriptionDto updateDto)
    {
        var prescription = await _unitOfWork.PrescriptionRepository.GetWithMedicinesAsync(updateDto.Id);
        if (prescription == null)
            throw new ArgumentException("Prescription not found");

        // Update basic prescription properties
        prescription.PrescriptionDate = updateDto.PrescriptionDate;
        prescription.Notes = updateDto.Notes;

        // Remove existing medicines
        await _unitOfWork.PrescriptionMedicineRepository.DeleteByPrescriptionIdAsync(prescription.Id);

        // Add updated medicines
        foreach (var medicineDto in updateDto.Medicines)
        {
            var prescriptionMedicine = new PrescriptionMedicine
            {
                PrescriptionId = prescription.Id,
                MedicineId = medicineDto.MedicineId,
                Quantity = medicineDto.Quantity,
                Dosage = medicineDto.Dosage,
                Instructions = medicineDto.Instructions,
                SumOfMedicationTime = medicineDto.SumOfMedicationTime,
                BoughtPrice = medicineDto.BoughtPrice
            };
            await _unitOfWork.PrescriptionMedicineRepository.CreateAsync(prescriptionMedicine);
        }

        _unitOfWork.PrescriptionRepository.Update(prescription);
        await _unitOfWork.SaveChangesAsync();

        return await GetPrescriptionByIdAsync(prescription.Id) ?? throw new InvalidOperationException("Failed to update prescription");
    }

    public async Task<bool> DeletePrescriptionAsync(Guid id)
    {
        var prescription = await _unitOfWork.PrescriptionRepository.GetByIdAsync(id);
        if (prescription == null)
            return false;

        // Delete related prescription medicines first
        await _unitOfWork.PrescriptionMedicineRepository.DeleteByPrescriptionIdAsync(id);
        
        _unitOfWork.PrescriptionRepository.Remove(prescription);
        return await _unitOfWork.SaveChangesAsync();
    }
    public async Task<bool> GetPrescriptionByMedicalRecordId(Guid medicalRecordId)
    {
        return await _unitOfWork.PrescriptionRepository.GetPrescriptionByMedicalRecordId(medicalRecordId);
    }
}
