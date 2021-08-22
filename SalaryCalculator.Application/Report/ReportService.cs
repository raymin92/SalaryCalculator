using System;
using System.Globalization;
using SalaryCalculator.Domain;
using SalaryCalculator.Domain.Enum;

namespace SalaryCalculator.Application.Report
{
    public class ReportService : IReportService
    {
        public void PrintSalaryDetails(Salary salary)
        {
            Console.WriteLine(GetReportString(salary));
        }

        private string GetReportString(Salary salary)
        {
            return $@"
Calculating salary details...

Gross package: {ToCurrency(salary.GrossPackage)}
Superannuation: {ToCurrency(salary.Superannuation)}

Taxable income: {ToCurrency(salary.TaxableIncome)}

Deductions:
Medicare Levy: {ToCurrency(salary.Deduction.MedicareLevy.Value)}
Budget Repair Levy: {ToCurrency(salary.Deduction.BudgetRepairLevy.Value)}
Income Tax: {ToCurrency(salary.Deduction.IncomeTax.Value)}

Net income: {ToCurrency(salary.NetIncome)}
Pay packet: {ToCurrency(salary.PayPacket)} per {salary.PayFrequency.GetDisplayName()}";
        }

        private string ToCurrency(decimal value)
        {
            return value.ToString("C", CultureInfo.CurrentCulture);
        }
    }
}
