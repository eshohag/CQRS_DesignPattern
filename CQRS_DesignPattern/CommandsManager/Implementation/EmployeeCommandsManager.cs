using CQRS_DesignPattern.CommandsManager.Interfaces;
using CQRS_DesignPattern.Models;
using CQRS_DesignPattern.Repositories.Interfaces;

namespace CQRS_DesignPattern.CommandsManager.Implementation
{
    public class EmployeeCommandsManager : IEmployeeCommandsManager
    {
        private readonly IEmployeeCommandsRepository _employeeCommandsRepository;
        public EmployeeCommandsManager(IEmployeeCommandsRepository employeeCommandsRepository)
        {
            _employeeCommandsRepository = employeeCommandsRepository;
        }

        public async Task<int> DeleteAsync(Employee employee)
        {
            var delete = await _employeeCommandsRepository.DeleteAsync(employee);
            return delete;
        }

        public async Task<int> AddAsync(Employee employee)
        {
            var addedEmployee = await _employeeCommandsRepository.AddAsync(employee);
            if (addedEmployee != null)
            {
                return 1;
            }
            return 0;
        }

        public async Task<int> UpdateAsync(Employee employee)
        {
            return await _employeeCommandsRepository.UpdateAsync(employee);
        }

    }
}