using Repository.Interfaces;
using Repository.Models;
using Service.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Service.Implements
{
    public class UserService : IUserService
    {
        private readonly IGenericRepository<ApplicationUser> _repo;

        public UserService(IGenericRepository<ApplicationUser> repo)
        {
            _repo = repo;
        }

        public ApplicationUser? GetAccountByUserName(string username)
        {
            return _repo.Query()
                .Include(u => u.Role)
                .FirstOrDefault(u => u.Username == username);
        }

        public async Task<ApplicationUser> CreateUser(ApplicationUser user)
        {
            user.Id = Guid.NewGuid();
            user.Status = "Active";
            await _repo.CreateAsync(user);
            return user;
        }

        public async Task<bool> UpdateUser(ApplicationUser user)
        {
            return await _repo.UpdateAsync(user);
        }

        public IList<ApplicationUser> GetAllEmployees()
        {
            return _repo.GetAll();
        }

        public async Task<ApplicationUser> CreateAsync(ApplicationUser user)
        {
            await _repo.CreateAsync(user);
            return user;
        }

        public async Task<List<ApplicationUser>> GetAll()
        {
            return await _repo.GetListAsync(p => p.RoleId == Guid.Parse("D4E5F6A7-0809-0123-4567-890123DEF012")); //RoleUser
        }

        public async Task<ApplicationUser> GetApplicationUserById(Guid id)
        {
            return await _repo.GetByIdAsync(id);
        }
    }
}