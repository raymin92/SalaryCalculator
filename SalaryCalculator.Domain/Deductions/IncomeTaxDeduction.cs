using System.Collections.Generic;
using SalaryCalculator.Domain.Options;

namespace SalaryCalculator.Domain.Deductions
{
    public class IncomeTaxDeduction : DeductionBase
    {
        public IncomeTaxDeduction(List<ExcessOption> options, decimal taxableIncome)
            : base(options, taxableIncome)
        {
        }
    }
}
