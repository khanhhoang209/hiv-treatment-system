using Service.DTOs;

namespace Service.Interfaces;

public interface IPrescriptionMedicineService
{
    Task<IEnumerable<PrescriptionMedicineDto>> GetMedicinesByPrescriptionIdAsync(Guid prescriptionId);
    Task<PrescriptionMedicineDto?> GetPrescriptionMedicineAsync(Guid prescriptionId, Guid medicineId);
    Task<PrescriptionMedicineDto> CreatePrescriptionMedicineAsync(Guid prescriptionId, CreatePrescriptionMedicineDto createDto);
    Task<PrescriptionMedicineDto> UpdatePrescriptionMedicineAsync(UpdatePrescriptionMedicineDto updateDto);
    Task<bool> DeletePrescriptionMedicineAsync(Guid prescriptionId, Guid medicineId);
    Task<bool> DeleteAllMedicinesByPrescriptionIdAsync(Guid prescriptionId);
}
