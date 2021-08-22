using SalaryCalculator.Domain;

namespace SalaryCalculator.Application.SalaryCalculation
{
    public interface ISalaryCalculateService
    {
        public Salary GetSalaryDetails(string grossPackage, string payFrequency);
    }
}
