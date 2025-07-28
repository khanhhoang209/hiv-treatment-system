using Repository.Interfaces;
using Repository.Models;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public async Task<List<ApplicationUser>> GetAll()
        {
            return await _repo.GetListAsync(p => p.RoleId == Guid.Parse("999f815a-526f-4af8-b4c6-d4625d81b220")); //RoleUser
        }

        public async Task<ApplicationUser> GetApplicationUserById(Guid id)
        {
            return await _repo.GetByIdAsync(id);
        }
    }
}
