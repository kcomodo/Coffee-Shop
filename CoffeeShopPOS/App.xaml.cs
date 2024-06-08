using POS_Folders.Repository;
using System.Configuration;
using System.Data;
using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using POS_Folders.Services;
namespace CoffeeShopPOS
{
    //REMEMBER SETUP DEPENDENCY INJECTION AND INSTALL LIBRARY USE THIS FORMAT:
    /*
     public partial class App : Application
{
    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);

        // Setup DI container
        var serviceProvider = new ServiceCollection()
            .AddScoped<IEmployeeRepository, EmployeeRepository>()
            .AddScoped<IEmployeeService, EmployeeService>()
            .BuildServiceProvider();

        // Resolve service
        var employeeService = serviceProvider.GetService<IEmployeeService>();

        // Use service...
    }
}




     */
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            // Setup DI container
            var serviceProvider = new ServiceCollection()
                .AddScoped<IEmployeeRepository, EmployeeRepository>()
                .AddScoped<IEmployeeServices,EmployeeServices>()
                .BuildServiceProvider();

            // Resolve service
            var employeeService = serviceProvider.GetService<IEmployeeServices>();

            // Use service...
        }
    }

}
