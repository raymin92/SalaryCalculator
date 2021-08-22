using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SalaryCalculator.Application.Report;
using SalaryCalculator.Application.SalaryCalculation;
using SalaryCalculator.Domain.Options;

namespace SalaryCalculator.Application
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services,
            IConfiguration configuration)
        {
            return services
                .AddSalaryCalculateServices(configuration)
                .AddReportServices();
        }

        private static IServiceCollection AddSalaryCalculateServices(this IServiceCollection services, IConfiguration configuration)
        {
            return services
                .Configure<SalaryOptions>(options =>
                    configuration.GetSection(nameof(SalaryOptions)).Bind(options))
                .AddScoped<ISalaryCalculateService, SalaryCalculateService>();
        }

        private static IServiceCollection AddReportServices(this IServiceCollection services)
        {
            return services
                .AddScoped<IReportService, ReportService>();
        }
    }
}
