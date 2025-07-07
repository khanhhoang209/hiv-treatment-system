using Microsoft.EntityFrameworkCore;
using Repository.Interfaces;
using Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface IUserService
    {
        Task<ApplicationUser> GetApplicationUserById(Guid id);
        Task<List<ApplicationUser>> GetAll();
        ApplicationUser? GetAccountByUserName(string username);
        Task<ApplicationUser> CreateUser(ApplicationUser user);
        Task<bool> UpdateUser(ApplicationUser user);
        //Task<ApplicationUser> GetByEmailAndPassword(string username, string password);
    }
}
