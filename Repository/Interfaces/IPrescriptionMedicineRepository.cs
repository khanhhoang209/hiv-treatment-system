using Repository.Models;

namespace Repository.Interfaces;

public interface IPrescriptionMedicineRepository : IGenericRepository<PrescriptionMedicine>
{
    Task<IEnumerable<PrescriptionMedicine>> GetByPrescriptionIdAsync(Guid prescriptionId);
    Task<PrescriptionMedicine?> GetByPrescriptionAndMedicineIdAsync(Guid prescriptionId, Guid medicineId);
    Task DeleteByPrescriptionIdAsync(Guid prescriptionId);
}
