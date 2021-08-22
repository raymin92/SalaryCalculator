using System;
using System.Collections.Generic;
using Microsoft.Extensions.Options;
using SalaryCalculator.Application.SalaryCalculation;
using SalaryCalculator.Domain.Enum;
using SalaryCalculator.Domain.Options;
using Xunit;

namespace SalaryPackage.Application.Test
{
    public class SalaryCalculateServiceTests
    {
        private readonly SalaryCalculateService _sut;
        private readonly IOptions<SalaryOptions> _options;

        public SalaryCalculateServiceTests()
        {
            _options = Options.Create(new SalaryOptions
            {
                SuperRate = 0.095M,
                MediCareLevyExcess = new List<ExcessOption>
                {
                    new ExcessOption
                    {
                        ExcessThreshold = 21335,
                        ExcessRate = 0.1M
                    },
                    new ExcessOption
                    {
                        ExcessThreshold = 26668,
                        ExcessRate = 0.02M
                    }
                },
                BudgetRepairLevyExcess = new List<ExcessOption>
                {
                    new ExcessOption
                    {
                        ExcessThreshold = 180000,
                        ExcessRate = 0.02M
                    }
                },
                IncomeTaxExcess = new List<ExcessOption>
                {
                    new ExcessOption
                    {
                        ExcessThreshold = 18200,
                        ExcessRate = 0.19M
                    },
                    new ExcessOption
                    {
                        ExcessThreshold = 37000,
                        ExcessRate = 0.325M
                    },
                    new ExcessOption
                    {
                        ExcessThreshold = 87000,
                        ExcessRate = 0.37M
                    },
                    new ExcessOption
                    {
                        ExcessThreshold = 180000,
                        ExcessRate = 0.47M
                    }
                }
            });
            _sut = new SalaryCalculateService(_options);
        }

        [Theory]
        [InlineData("", "M")]
        [InlineData("NotDecimal", "M")]
        public void GetSalaryDetails_throws_error_when_gross_package_is_not_decimal(string grossPackage, string payFrequency)
        {
            // Act
            void act() => _sut.GetSalaryDetails(grossPackage, payFrequency);

            // Assert
            var ex = Assert.Throws<ArgumentException>(act);
            Assert.Equal("Entered gross package value is not numeric.", ex.Message);
        }

        [Theory]
        [InlineData("-0.1", "M")]
        [InlineData("-180000", "M")]
        public void GetSalaryDetails_throws_error_when_gross_package_is_invalid(string grossPackage, string payFrequency)
        {
            // Act
            void act() => _sut.GetSalaryDetails(grossPackage, payFrequency);

            // Assert
            var ex = Assert.Throws<ArgumentException>(act);
            Assert.Equal("Entered gross package value is not positive.", ex.Message);
        }

        [Theory]
        [InlineData("1", "")]
        [InlineData("1", "A")]
        public void GetSalaryDetails_throws_error_when_pay_frequency_is_invalid(string grossPackage, string payFrequency)
        {
            // Act
            void act() => _sut.GetSalaryDetails(grossPackage, payFrequency);

            // Assert
            var ex = Assert.Throws<ArgumentException>(act);
            Assert.Equal("Entered pay frequency value is invalid.", ex.Message);
        }

        [Theory]
        [InlineData("0", "M", 0)]
        [InlineData("27375", "M", 367)]
        [InlineData("43800", "M", 800)]
        public void GetSalaryDetails_returns_correct_medicare_levy(string grossPackage, string payFrequency, int expectedAmount)
        {
            // Act
            var result = _sut.GetSalaryDetails(grossPackage, payFrequency);

            // Assert
            Assert.Equal(expectedAmount, result.Deduction.MedicareLevy.Value);
        }

        [Theory]
        [InlineData("0", "M", 0)]
        [InlineData("219000", "M", 400)]
        public void GetSalaryDetails_returns_correct_budget_repair_levy(string grossPackage, string payFrequency, int expectedAmount)
        {
            // Act
            var result = _sut.GetSalaryDetails(grossPackage, payFrequency);

            // Assert
            Assert.Equal(expectedAmount, result.Deduction.BudgetRepairLevy.Value);
        }

        [Theory]
        [InlineData("0", "M", 0)]
        [InlineData("27375", "M", 1292)]
        [InlineData("49275", "M", 6172)]
        [InlineData("104025", "M", 22782)]
        [InlineData("197100", "M", 54232)]
        [InlineData("219000", "M", 63632)]
        public void GetSalaryDetails_returns_correct_income_tax(string grossPackage, string payFrequency, int expectedAmount)
        {
            // Act
            var result = _sut.GetSalaryDetails(grossPackage, payFrequency);

            // Assert
            Assert.Equal(expectedAmount, result.Deduction.IncomeTax.Value);
        }

        [Fact]
        public void GetSalaryDetails_returns_salary_when_input_is_good()
        {
            // Arrange
            var grossPackage = "65000";
            var payFrequency = PayFrequency.M.ToString();

            // Act
            var result = _sut.GetSalaryDetails(grossPackage, payFrequency);

            // Assert
            Assert.Equal(65000, result.GrossPackage);
            Assert.Equal(5639.27M, result.Superannuation);
            Assert.Equal(59360.73M, result.TaxableIncome);
            Assert.Equal(1188, result.Deduction.MedicareLevy.Value);
            Assert.Equal(0, result.Deduction.BudgetRepairLevy.Value);
            Assert.Equal(10839, result.Deduction.IncomeTax.Value);
            Assert.Equal(47333.73M, result.NetIncome);
            Assert.Equal(3944.48M, result.PayPacket);
        }
    }
}
