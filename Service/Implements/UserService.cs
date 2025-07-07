using Repository.Interfaces;
using Repository.Models;
using Service.Interfaces;

namespace Service.Implements;

public class UserService : IUserService
{
    private readonly IGenericRepository<ApplicationUser> _repo;
    
    public UserService(IGenericRepository<ApplicationUser> repo)
    {
        _repo = repo;
    }
    public ApplicationUser? GetAccountByUserName(string username)
    {
        return _repo.GetAll().FirstOrDefault(u => u.Username == username);
    }
    
}