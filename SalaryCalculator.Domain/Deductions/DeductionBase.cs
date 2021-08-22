using System;
using System.Collections.Generic;
using System.Linq;
using SalaryCalculator.Domain.Options;

namespace SalaryCalculator.Domain.Deductions
{
    public class DeductionBase
    {
        public DeductionBase(List<ExcessOption> excesseOptions, decimal taxableIncome)
        {
            ExcesseOptions = excesseOptions;
            Value = CalculateExcess(taxableIncome);
        }

        public virtual int Value { get; set; }

        public virtual List<ExcessOption> ExcesseOptions { get; set; }


        internal virtual int CalculateExcess(decimal taxableIncome)
        {
            var total = 0M;
            var list = ExcesseOptions.OrderBy(e => e.ExcessThreshold).ToList();

            for (int i = 0; i < list.Count; i++)
            {
                var current = list[i];

                if (i + 1 < list.Count && taxableIncome > list[i + 1].ExcessThreshold)
                {
                    total += Math.Floor((decimal)(list[i + 1].ExcessThreshold - current.ExcessThreshold)) * current.ExcessRate;
                }
                else
                {
                    total += Math.Floor((taxableIncome - current.ExcessThreshold)) * current.ExcessRate;
                    break;
                }
            }

            return total > 0 ? (int)Math.Ceiling(total) : 0;
        }
    }
}
