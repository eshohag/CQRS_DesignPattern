using CQRS_DesignPattern.Models;

namespace CQRS_DesignPattern.CommandsManager.Interfaces
{
    public interface IEmployeeCommandsManager
    {
        Task<int> AddAsync(Employee employee);
        Task<int> DeleteAsync(Employee employee);
        Task<int> UpdateAsync(Employee employee);
    }
}
