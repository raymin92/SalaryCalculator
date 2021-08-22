using System;
using SalaryCalculator.Domain.Enum;
using SalaryCalculator.Domain.Options;

namespace SalaryCalculator.Domain
{
    public class Salary
    {
        public Salary(decimal grossPackage, PayFrequency payFrequency, SalaryOptions options)
        {
            GrossPackage = grossPackage;
            PayFrequency = payFrequency;
            Superannuation = Math.Round(GrossPackage * options.SuperRate / (1 + options.SuperRate), 2);
            Deduction = new Deduction(TaxableIncome, options);
        }

        public decimal GrossPackage { get; set; }
        public PayFrequency PayFrequency { get; set; }
        public decimal Superannuation { get; set; }
        public decimal TaxableIncome => GrossPackage - Superannuation;

        public Deduction Deduction { get; set; }
        public decimal NetIncome => TaxableIncome - Deduction.Total;

        public decimal PayPacket => PayFrequency.Equals(PayFrequency.W)
            ? Math.Round(NetIncome / 52, 2)
            : PayFrequency.Equals(PayFrequency.F)
            ? Math.Round(NetIncome / 26, 2)
            : Math.Round(NetIncome / 12, 2);
    }
}
