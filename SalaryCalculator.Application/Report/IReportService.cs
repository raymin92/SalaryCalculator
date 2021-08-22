using SalaryCalculator.Domain;

namespace SalaryCalculator.Application.Report
{
    public interface IReportService
    {
        public void PrintSalaryDetails(Salary salary);
    }
}
