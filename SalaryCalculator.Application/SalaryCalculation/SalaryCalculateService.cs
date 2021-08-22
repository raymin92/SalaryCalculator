using System;
using Microsoft.Extensions.Options;
using SalaryCalculator.Domain;
using SalaryCalculator.Domain.Enum;
using SalaryCalculator.Domain.Options;

namespace SalaryCalculator.Application.SalaryCalculation
{
    public class SalaryCalculateService : ISalaryCalculateService
    {
        private readonly SalaryOptions _options;

        public SalaryCalculateService(IOptions<SalaryOptions> options)
        {
            _options = options.Value;
        }

        public Salary GetSalaryDetails(string grossPackage, string payFrequency)
        {
            if (!decimal.TryParse(grossPackage, out var grossPackageValue))
            {
                throw new ArgumentException("Entered gross package value is not numeric.");
            }
            if (grossPackageValue < 0)
            {
                throw new ArgumentException("Entered gross package value is not positive.");
            }
            if (!Enum.TryParse<PayFrequency>(payFrequency, out var payFrequencyValue))
            {
                throw new ArgumentException("Entered pay frequency value is invalid.");
            }

            return new Salary(grossPackageValue, payFrequencyValue, _options);
        }
    }
}
