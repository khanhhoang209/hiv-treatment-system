using Microsoft.EntityFrameworkCore;
using Repository.Context;
using Repository.Interfaces;
using Repository.Models;

namespace Repository.Implements;

public class PrescriptionMedicineRepository : GenericRepository<PrescriptionMedicine>, IPrescriptionMedicineRepository
{
    public PrescriptionMedicineRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<IEnumerable<PrescriptionMedicine>> GetByPrescriptionIdAsync(Guid prescriptionId)
    {
        return await _dbContext.Set<PrescriptionMedicine>()
            .Include(pm => pm.Medicine)
            .Where(pm => pm.PrescriptionId == prescriptionId)
            .ToListAsync();
    }

    public async Task<PrescriptionMedicine?> GetByPrescriptionAndMedicineIdAsync(Guid prescriptionId, Guid medicineId)
    {
        return await _dbContext.Set<PrescriptionMedicine>()
            .Include(pm => pm.Medicine)
            .FirstOrDefaultAsync(pm => pm.PrescriptionId == prescriptionId && pm.MedicineId == medicineId);
    }

    public async Task DeleteByPrescriptionIdAsync(Guid prescriptionId)
    {
        var prescriptionMedicines = await _dbContext.Set<PrescriptionMedicine>()
            .Where(pm => pm.PrescriptionId == prescriptionId)
            .ToListAsync();
        
        _dbContext.Set<PrescriptionMedicine>().RemoveRange(prescriptionMedicines);
    }
}
