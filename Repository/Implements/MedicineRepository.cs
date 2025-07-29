using Microsoft.EntityFrameworkCore;
using Repository.Context;
using Repository.Interfaces;
using Repository.Models;

namespace Repository.Implements;

public class MedicineRepository : GenericRepository<Medicine>, IMedicineRepository
{
    public MedicineRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
    
}