using Repository.Interfaces;
using Repository.Models;
using Service.Interfaces;

namespace Service.Implements;

public class MedicineService : IMedicineService
{
    private readonly IUnitOfWork _unitOfWork;
    public MedicineService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public async Task<List<Medicine>> GetAllAsync()
    {
        var medicines = await _unitOfWork.MedicineRepository.GetAllAsync();
        return medicines;
    }
    
}