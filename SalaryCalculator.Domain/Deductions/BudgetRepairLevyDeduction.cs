using System.Collections.Generic;
using SalaryCalculator.Domain.Options;

namespace SalaryCalculator.Domain.Deductions
{
    public class BudgetRepairLevyDeduction : DeductionBase
    {
        public BudgetRepairLevyDeduction(List<ExcessOption> options, decimal taxableIncome)
            : base(options, taxableIncome)
        {
        }
    }
}
