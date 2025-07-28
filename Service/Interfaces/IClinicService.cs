using Repository.Models;

namespace Service.Interfaces;

public interface IClinicService
{
    Task<List<Clinic>> GetClinics();
    Task<Clinic?> GetClinicById(Guid id);
    Task<Clinic> CreateClinic(Clinic clinic);
    Task<Clinic> UpdateClinic(Clinic clinic);
    Task<bool> DeleteClinic(Clinic clinic);

}