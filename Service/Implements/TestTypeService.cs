using Repository.Interfaces;
using Service.Interfaces;
using Type = Repository.Models.Type;

namespace Service.Implements;

public class TestTypeService : ITestTypeService
{
    private readonly IGenericRepository<Type> _repo;

    public TestTypeService(IGenericRepository<Type> repo)
    {
        _repo = repo;
    }

    public async Task<IList<Type>> GetAllAsync()
    {
        return await _repo.GetAllAsync();
    }
}