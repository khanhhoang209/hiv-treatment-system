using Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface IEmployeeService
    {
        Task<Employee> GetEmployee(Guid id);
        IEnumerable<Employee> GetEmployees();
        Task<IList<Employee>> GetAllAsync();
        Task<Employee?> GetEmployeeByIdAsync(Guid id);
        Task<Employee> CreateAsync(Employee employee);
        Task<Employee> UpdateAsync(Employee employee, Guid roleId);
        Task<bool> DeleteAsync(Employee employee);
    }
}