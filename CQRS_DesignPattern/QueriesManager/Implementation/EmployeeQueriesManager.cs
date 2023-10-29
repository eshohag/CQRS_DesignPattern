using CQRS_DesignPattern.Models;
using CQRS_DesignPattern.QueriesManager.Interfaces;
using CQRS_DesignPattern.Repositories.Interfaces;

namespace CQRS_DesignPattern.QueriesManager.Implementation
{
    public class EmployeeQueriesManager : IEmployeeQueriesManager
    {
        private readonly IEmployeeQueriesRepository _employeeQueriesRepository;

        public EmployeeQueriesManager(IEmployeeQueriesRepository employeeQueriesRepository)
        {
            _employeeQueriesRepository = employeeQueriesRepository;
        }
        public async Task<Employee> FindByIdAsync(int employeeId)
        {
            var employee = await _employeeQueriesRepository.GetByIdAsync(employeeId);
            return employee;
        }

        public IQueryable<Employee> GetAll()
        {
            return _employeeQueriesRepository.All();
        }
    }
}
