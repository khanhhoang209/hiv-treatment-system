using Microsoft.EntityFrameworkCore;
using Repository.Interfaces;
using Repository.Models;
using Service.Interfaces;

namespace Service.Implements
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IGenericRepository<Employee> _repo;
        private readonly IUnitOfWork _unitOfWork;
        public EmployeeService(IGenericRepository<Employee> employeeRepo, IUnitOfWork unitOfWork)
        {
            _repo = employeeRepo;
            _unitOfWork = unitOfWork;
        }
        public async Task<Employee> GetEmployee(Guid id)
        {
            return await _repo.GetByIdAsync(id);
        }

        public IEnumerable<Employee> GetEmployees()
        {
            return _unitOfWork.EmployeeRepository.GetAll();
        }

        public async Task<IList<Employee>> GetAllAsync()
        {
            return await _unitOfWork.EmployeeRepository
                .Query()
                .Include(e => e.Qualifications)
                .Include(e => e.Doctor)
                .Include(e => e.Staff)
                .Include(e => e.User).ThenInclude(e => e.Role)
                .Where(e => e.User.Role.Name != "Admin")
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Employee?> GetEmployeeByIdAsync(Guid id)
        {
            return await _unitOfWork.EmployeeRepository
                .Query()
                .Include(e => e.Qualifications)
                .Include(e => e.Doctor)
                .Include(e => e.Staff)
                .Include(e => e.User).ThenInclude(e => e.Role)
                .AsNoTracking()
                .FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<Employee> CreateAsync(Employee employee)
        {
            await _unitOfWork.EmployeeRepository.CreateAsync(employee);
            return employee;
        }

        public async Task<Employee> UpdateAsync(Employee employee, Guid roleId)
        {
            var availbleEmployee = await _unitOfWork.EmployeeRepository
                .Query()
                .Include(e => e.User)
                .FirstOrDefaultAsync(e => e.Id == employee.Id);

            availbleEmployee.FirstName = employee.FirstName;
            availbleEmployee.LastName = employee.LastName;
            availbleEmployee.Email = employee.Email;
            availbleEmployee.Phone = employee.Phone;
            availbleEmployee.Address = employee.Address;
            availbleEmployee.DateOfBirth = employee.DateOfBirth;
            availbleEmployee.Gender = employee.Gender;
            availbleEmployee.Status = employee.Status;
            availbleEmployee.User.RoleId = roleId;

            await _unitOfWork.EmployeeRepository.UpdateAsync(availbleEmployee);

            return availbleEmployee;
        }

        public async Task<bool> DeleteAsync(Employee employee)
        {
            var availableEmployee = await _unitOfWork.EmployeeRepository.GetByIdAsync(employee.Id);
            if (availableEmployee != null)
            {
                return await _unitOfWork.EmployeeRepository.RemoveAsync(availableEmployee);
            }
            return false;
        }
    }
}