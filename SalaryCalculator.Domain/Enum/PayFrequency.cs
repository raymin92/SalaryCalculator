using System.ComponentModel.DataAnnotations;

namespace SalaryCalculator.Domain.Enum
{
    public enum PayFrequency
    {
        [Display(Name = "week")]
        W,
        [Display(Name = "fortnight")]
        F,
        [Display(Name = "month")]
        M
    }
}
