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
            Console.WriteLine();
            Console.WriteLine("Calculating salary details...");
            Console.WriteLine();
            Console.WriteLine($"Gross package: {salary.GrossPackage.ToString("C", CultureInfo.CurrentCulture)}");
            Console.WriteLine($"Superannuation: {salary.Superannuation.ToString("C", CultureInfo.CurrentCulture)}");
            Console.WriteLine();
            Console.WriteLine($"Taxable income: {salary.TaxableIncome.ToString("C", CultureInfo.CurrentCulture)}");
            Console.WriteLine();
            Console.WriteLine("Deductions:");
            Console.WriteLine($"Medicare Levy: {salary.Deduction.MedicareLevy.Value.ToString("C", CultureInfo.CurrentCulture)}");
            Console.WriteLine($"Budget Repair Levy: {salary.Deduction.BudgetRepairLevy.Value.ToString("C", CultureInfo.CurrentCulture)}");
            Console.WriteLine($"Income Tax: {salary.Deduction.IncomeTax.Value.ToString("C", CultureInfo.CurrentCulture)}");
            Console.WriteLine();
            Console.WriteLine($"Net income: {salary.NetIncome.ToString("C", CultureInfo.CurrentCulture)}");
            Console.WriteLine($"Pay packet: {salary.PayPacket.ToString("C", CultureInfo.CurrentCulture)} per {salary.PayFrequency.GetDisplayName()}");
        }
    }
}
