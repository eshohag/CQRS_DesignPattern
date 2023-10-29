using CQRS_DesignPattern.Models;

namespace CQRS_DesignPattern.QueriesManager.Interfaces
{
    public interface IEmployeeQueriesManager
    {
        Task<Employee> FindByIdAsync(int employeeId);
        IQueryable<Employee> GetAll();
    }
}
