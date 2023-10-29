using CQRS_DesignPattern.CommandsManager.Implementation;
using CQRS_DesignPattern.CommandsManager.Interfaces;
using CQRS_DesignPattern.QueriesManager.Implementation;
using CQRS_DesignPattern.QueriesManager.Interfaces;
using CQRS_DesignPattern.Repositories.Implementation;
using CQRS_DesignPattern.Repositories.Interfaces;

namespace CQRS_DesignPattern
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDependencyInjection(this IServiceCollection services)
        {
            services.AddScoped<IEmployeeQueriesManager, EmployeeQueriesManager>(); 
            services.AddScoped<IEmployeeQueriesRepository, EmployeeQueriesRepository>();

            services.AddScoped<IEmployeeCommandsManager, EmployeeCommandsManager>();
            services.AddScoped<IEmployeeCommandsRepository, EmployeeCommandsRepository>();

            services.AddScoped<IEmployeeQueriesRepository, EmployeeQueriesRepository>();
            services.AddScoped<IEmployeeCommandsRepository, EmployeeCommandsRepository>();

            return services;
        }
    }
}
