using CQRS_DesignPattern.Models;

namespace CQRS_DesignPattern.Repositories.Interfaces
{
    public interface IEmployeeQueriesRepository
    {
        IQueryable<Employee> All();
        Task<Employee> GetByIdAsync(int employeeId);
    }
}
