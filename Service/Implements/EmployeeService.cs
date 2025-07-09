using Repository.Interfaces;
using Repository.Models;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Implements
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IGenericRepository<Employee> _repo;
        public EmployeeService(IGenericRepository<Employee> employeeRepo)
        {
            _repo = employeeRepo;
        }
        public async Task<Employee> GetEmployee(Guid id)
        {
            return await _repo.GetByIdAsync(id);
        }
    }
}
