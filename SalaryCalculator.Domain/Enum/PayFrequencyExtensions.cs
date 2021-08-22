using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;

namespace SalaryCalculator.Domain.Enum
{
    public static class PayFrequencyExtensions
    {
        public static string GetDisplayName(this PayFrequency payFrequency)
        {
            return payFrequency.GetType()
                .GetMember(payFrequency.ToString())
                .First()
                .GetCustomAttribute<DisplayAttribute>()
                .GetName();
        }
    }
}
