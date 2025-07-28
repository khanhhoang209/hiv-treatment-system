using Repository.Context;
using Repository.Interfaces;
using Repository.Models;

namespace Repository.Implements;

public class ClinicRepository : GenericRepository<Clinic>, IClinicRepository
{
    public ClinicRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}