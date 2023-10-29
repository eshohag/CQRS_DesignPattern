using CQRS_DesignPattern.Models;

namespace CQRS_DesignPattern.Repositories.Interfaces
{
    public interface IEmployeeCommandsRepository
    {
        Task<int> DeleteAsync(Employee employee);
        Task<Employee> AddAsync(Employee employee);
        Task<int> UpdateAsync(Employee employee);
    }
}
