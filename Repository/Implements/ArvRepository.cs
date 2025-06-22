using Microsoft.EntityFrameworkCore;
using Repository.Context;
using Repository.Interfaces;
using Repository.Models;

namespace Repository.Implements;

public class ArvRepository : GenericRepository<ArvRegimen>, IArvRepository
{
    public ArvRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<ArvRegimen> GetByPatient(string patient)
    {
        var arv = await _dbContext.ArvRegimens.FirstOrDefaultAsync(a => a.Description.ToLower().Contains(patient.ToLower()));
        return arv!;
    }
}