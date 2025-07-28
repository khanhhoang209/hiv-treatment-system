using Type = Repository.Models.Type;

namespace Service.Interfaces;

public interface ITestTypeService
{
    Task<IList<Type>> GetAllAsync();
}