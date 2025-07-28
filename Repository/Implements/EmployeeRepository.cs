using Repository.Context;
using Repository.Interfaces;
using Repository.Models;

namespace Repository.Implements;

public class EmployeeRepository : GenericRepository<Employee>, IEmployeeRepository
{
    public EmployeeRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}