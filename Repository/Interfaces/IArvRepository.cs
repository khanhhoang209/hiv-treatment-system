using Repository.Models;

namespace Repository.Interfaces;

public interface IArvRepository : IGenericRepository<ArvRegimen>
{
    Task<ArvRegimen> GetByPatient(string patient);

}