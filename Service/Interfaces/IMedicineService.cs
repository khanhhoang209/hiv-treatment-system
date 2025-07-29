using Repository.Models;

namespace Service.Interfaces;

public interface IMedicineService
{
    Task<List<Medicine>> GetAllAsync();
}