using CQRS_DesignPattern.Models;
using CQRS_DesignPattern.Repositories.Interfaces;

namespace CQRS_DesignPattern.Repositories.Implementation
{
    public class EmployeeCommandsRepository : IEmployeeCommandsRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public EmployeeCommandsRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<Employee> AddAsync(Employee employee)
        {
            _applicationDbContext.Employees.Add(employee);
            int rowAffect = await _applicationDbContext.SaveChangesAsync();
            if (rowAffect > 0)
            {
                return employee;
            }
            return null;
        }

        public async Task<int> UpdateAsync(Employee employee)
        {
            _applicationDbContext.Update(employee);
            return await _applicationDbContext.SaveChangesAsync();
        }

        public async Task<int> DeleteAsync(Employee employee)
        {
            _applicationDbContext.Remove(employee);
            return await _applicationDbContext.SaveChangesAsync();
        }
    }
}
