using System;
using System.Collections.Generic;
using System.Linq;
using SalaryCalculator.Domain.Options;

namespace SalaryCalculator.Domain.Deductions
{
    public class MedicareLevyDeduction : DeductionBase
    {
        public MedicareLevyDeduction(List<ExcessOption> options, decimal taxableIncome)
            : base(options, taxableIncome)
        {
        }

        internal override int CalculateExcess(decimal taxableIncome)
        {
            var topExcess = ExcesseOptions.OrderByDescending(e => e.ExcessThreshold).FirstOrDefault();
            return taxableIncome > topExcess.ExcessThreshold
                ? (int)Math.Ceiling(taxableIncome * topExcess.ExcessRate)
                : base.CalculateExcess(taxableIncome);
        }
    }
}
