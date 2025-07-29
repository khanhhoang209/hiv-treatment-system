using Repository.Interfaces;
using Repository.Models;
using Service.Interfaces;

namespace Service.Implements;

public class RoleService : IRoleService
{
    private readonly IGenericRepository<Role> _roleRepository;

    public RoleService(IGenericRepository<Role> roleRepository)
    {
        _roleRepository = roleRepository;
    }

    public IList<Role> GetRoles()
    {
        return _roleRepository.Query().Where(r => r.Name != "Admin").ToList();
    }
}