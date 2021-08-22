using System;
using System.Reflection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using SalaryCalculator.Application;
using SalaryCalculator.Application.Report;
using SalaryCalculator.Application.SalaryCalculation;

namespace SalaryCalculator
{
    public class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = ConfigureServices();
            var salaryCalculateService = serviceProvider.GetService<ISalaryCalculateService>();
            var reportService = serviceProvider.GetService<IReportService>();

            Console.Write("Enter your salary package amount: ");
            var grossPackage = Console.ReadLine();

            Console.Write("Enter your pay frequency (W for weekly, F for fortnightly, M for monthly): ");
            var payFrequency = Console.ReadLine();

            try
            {
                var salary = salaryCalculateService.GetSalaryDetails(grossPackage, payFrequency);
                reportService.PrintSalaryDetails(salary);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        private static IServiceProvider ConfigureServices()
        {
            var services = new ServiceCollection();
            var configuration = BuildConfiguration();
            services.AddApplicationServices(configuration);
            return services.BuildServiceProvider();
        }

        private static IConfiguration BuildConfiguration()
        {
            var embeddedProvider = new EmbeddedFileProvider(Assembly.GetExecutingAssembly());
            var configBuilder = new ConfigurationBuilder();
            configBuilder
                .AddJsonFile(embeddedProvider, "appsettings.json", optional: false, reloadOnChange: false);

            return configBuilder.Build();
        }
    }
}
