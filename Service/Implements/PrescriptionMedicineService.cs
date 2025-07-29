using AutoMapper;
using Repository.Interfaces;
using Repository.Models;
using Service.DTOs;
using Service.Interfaces;

namespace Service.Implements;

public class PrescriptionMedicineService : IPrescriptionMedicineService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public PrescriptionMedicineService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<IEnumerable<PrescriptionMedicineDto>> GetMedicinesByPrescriptionIdAsync(Guid prescriptionId)
    {
        var prescriptionMedicines = await _unitOfWork.PrescriptionMedicineRepository.GetByPrescriptionIdAsync(prescriptionId);
        return _mapper.Map<IEnumerable<PrescriptionMedicineDto>>(prescriptionMedicines);
    }

    public async Task<PrescriptionMedicineDto?> GetPrescriptionMedicineAsync(Guid prescriptionId, Guid medicineId)
    {
        var prescriptionMedicine = await _unitOfWork.PrescriptionMedicineRepository.GetByPrescriptionAndMedicineIdAsync(prescriptionId, medicineId);
        return prescriptionMedicine != null ? _mapper.Map<PrescriptionMedicineDto>(prescriptionMedicine) : null;
    }

    public async Task<PrescriptionMedicineDto> CreatePrescriptionMedicineAsync(Guid prescriptionId, CreatePrescriptionMedicineDto createDto)
    {
        var prescriptionMedicine = new PrescriptionMedicine
        {
            PrescriptionId = prescriptionId,
            MedicineId = createDto.MedicineId,
            Quantity = createDto.Quantity,
            Dosage = createDto.Dosage,
            Instructions = createDto.Instructions,
            SumOfMedicationTime = createDto.SumOfMedicationTime,
            BoughtPrice = createDto.BoughtPrice
        };

        await _unitOfWork.PrescriptionMedicineRepository.CreateAsync(prescriptionMedicine);
        await _unitOfWork.SaveChangesAsync();

        var result = await GetPrescriptionMedicineAsync(prescriptionId, createDto.MedicineId);
        return result ?? throw new InvalidOperationException("Failed to create prescription medicine");
    }

    public async Task<PrescriptionMedicineDto> UpdatePrescriptionMedicineAsync(UpdatePrescriptionMedicineDto updateDto)
    {
        var prescriptionMedicine = await _unitOfWork.PrescriptionMedicineRepository.GetByPrescriptionAndMedicineIdAsync(updateDto.PrescriptionId, updateDto.MedicineId);
        if (prescriptionMedicine == null)
            throw new ArgumentException("Prescription medicine not found");

        prescriptionMedicine.Quantity = updateDto.Quantity;
        prescriptionMedicine.Dosage = updateDto.Dosage;
        prescriptionMedicine.Instructions = updateDto.Instructions;
        prescriptionMedicine.SumOfMedicationTime = updateDto.SumOfMedicationTime;
        prescriptionMedicine.BoughtPrice = updateDto.BoughtPrice;

        _unitOfWork.PrescriptionMedicineRepository.Update(prescriptionMedicine);
        await _unitOfWork.SaveChangesAsync();

        var result = await GetPrescriptionMedicineAsync(updateDto.PrescriptionId, updateDto.MedicineId);
        return result ?? throw new InvalidOperationException("Failed to update prescription medicine");
    }

    public async Task<bool> DeletePrescriptionMedicineAsync(Guid prescriptionId, Guid medicineId)
    {
        var prescriptionMedicine = await _unitOfWork.PrescriptionMedicineRepository.GetByPrescriptionAndMedicineIdAsync(prescriptionId, medicineId);
        if (prescriptionMedicine == null)
            return false;

        _unitOfWork.PrescriptionMedicineRepository.Remove(prescriptionMedicine);
        return await _unitOfWork.SaveChangesAsync();
    }

    public async Task<bool> DeleteAllMedicinesByPrescriptionIdAsync(Guid prescriptionId)
    {
        await _unitOfWork.PrescriptionMedicineRepository.DeleteByPrescriptionIdAsync(prescriptionId);
        return await _unitOfWork.SaveChangesAsync();
    }
}
