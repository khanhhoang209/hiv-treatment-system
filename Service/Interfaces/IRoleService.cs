using Repository.Models;

namespace Service.Interfaces;

public interface IRoleService
{
    IList<Role> GetRoles();
}