using System.Collections.Generic;

namespace SalaryCalculator.Domain.Options
{
    public class SalaryOptions
    {
        public decimal SuperRate { get; set; }
        public List<ExcessOption> MediCareLevyExcess { get; set; }
        public List<ExcessOption> BudgetRepairLevyExcess { get; set; }
        public List<ExcessOption> IncomeTaxExcess { get; set; }
    }

    public class ExcessOption
    {
        public int ExcessThreshold { get; set; }
        public decimal ExcessRate { get; set; }
    }
}
