using Repository.Interfaces;
using Repository.Models;
using Service.Interfaces;

namespace Service.Implements;

public class ClinicService : IClinicService
{
    private readonly IUnitOfWork _unitOfWork;

    public ClinicService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<List<Clinic>> GetClinics()
    {
        return await _unitOfWork.ClinicRepository.GetAllAsync();
    }

    public async Task<Clinic?> GetClinicById(Guid id)
    {
        return await _unitOfWork.ClinicRepository.GetByIdAsync(id);
    }

    public async Task<Clinic> CreateClinic(Clinic clinic)
    {
        await _unitOfWork.ClinicRepository.CreateAsync(clinic);
        return clinic;
    }

    public async Task<Clinic> UpdateClinic(Clinic clinic)
    {
        await _unitOfWork.ClinicRepository.UpdateAsync(clinic);
        return clinic;
    }

    public async Task<bool> DeleteClinic(Clinic clinic)
    {
        var result = await _unitOfWork.ClinicRepository.RemoveAsync(clinic);
        return result;
    }
}