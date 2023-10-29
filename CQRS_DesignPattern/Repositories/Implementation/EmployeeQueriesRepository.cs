using CQRS_DesignPattern.Models;
using CQRS_DesignPattern.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace CQRS_DesignPattern.Repositories.Implementation
{
    public class EmployeeQueriesRepository : IEmployeeQueriesRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public EmployeeQueriesRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public IQueryable<Employee> All()
        {
            return _applicationDbContext.Employees.AsQueryable();
        }

        public async Task<Employee> GetByIdAsync(int employeeId)
        {
            var employee = await _applicationDbContext.Employees.FirstOrDefaultAsync(a => a.Id == employeeId);
            return employee;
        }
    }
}
