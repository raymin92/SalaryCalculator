using SalaryCalculator.Domain.Deductions;
using SalaryCalculator.Domain.Options;

namespace SalaryCalculator.Domain
{
    public class Deduction
    {
        public Deduction(decimal taxableIncome, SalaryOptions options)
        {
            MedicareLevy = new MedicareLevyDeduction(options.MediCareLevyExcess, taxableIncome);
            BudgetRepairLevy = new BudgetRepairLevyDeduction(options.BudgetRepairLevyExcess, taxableIncome);
            IncomeTax = new IncomeTaxDeduction(options.IncomeTaxExcess, taxableIncome);
        }

        public MedicareLevyDeduction MedicareLevy { get; set; }
        public BudgetRepairLevyDeduction BudgetRepairLevy { get; set; }
        public IncomeTaxDeduction IncomeTax { get; set; }
        public int Total => MedicareLevy.Value + BudgetRepairLevy.Value + IncomeTax.Value;
    }
}
