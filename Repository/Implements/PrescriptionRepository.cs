using Repository.Context;
using Repository.Interfaces;
using Repository.Models;

namespace Repository.Implements;

public class PrescriptionRepository : GenericRepository<Prescription>, IPrescriptionRepository
{
    public PrescriptionRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}