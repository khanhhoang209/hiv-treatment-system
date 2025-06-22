using Repository.Models;

namespace Service.Interfaces;

public interface IUserService
{
    public ApplicationUser? GetAccountByUserName(string username);
    
}