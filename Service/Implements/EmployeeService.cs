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
    }
}