using Repository.Models;
using Service.DTOs;

namespace Service.Interfaces;

public interface IArvService
{
    Task<List<ArvRegimen>> GetAllAsync();
    Task<ArvRegimen> GetByIdAsync(Guid id);
    Task<ArvRegimen> CreateAsync(ArvRegimen arvRegimen);
    Task<ArvRegimen> UpdateAsync(ArvRegimen arvRegimen);
    Task DeleteAsync(Guid id);
    Task<List<ArvRegimen>> GetSuggestedRegimensAsync(PatientCondition patientCondition);
}