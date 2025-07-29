using Microsoft.EntityFrameworkCore;
using Repository.Context;
using Repository.Interfaces;
using Repository.Models;

namespace Repository.Implements;

public class ComboMedicineRepository : GenericRepository<ComboMedicine>, IComboMedicineRepository
{
    public ComboMedicineRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
    
}