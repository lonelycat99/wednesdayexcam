using System;
using System.Collections.Generic;
using System.Linq;
using MyApp.API;
using MyApp.API.Models;
using Xunit;
using FluentAssertions;

namespace MyApp.Test
{
    public class UnitTest1
    {
        [Theory]
        [MemberData(nameof(Data))]
        public void TestCalLoanInterest(double balance, int increase, int years, List<AnnualAmount> expected)
        {
            var sut = new CalculateAnnualAmount();
            var result = sut.CalLoanInterest(balance, increase, years);
            result.Should().BeEquivalentTo(expected);
        }

        [Theory]
        [InlineData(1500, 10, 150)]
        [InlineData(25000, 7, 1750)]
        [InlineData(32600, 5, 1630)]
        [InlineData(75200, 11, 8272)]
        [InlineData(6200, 14, 868)]
        public void TestCalIncrease(double balance, int increase, double expected)
        {
            var sut = new CalculateAnnualAmount();
            var result = sut.CalIncrease(balance, increase);
            result.Should().Be(expected);
        }

        [Theory]
        [InlineData(15000, 323, 15323)]
        [InlineData(5200, 120, 5320)]
        [InlineData(75565, 45, 75610)]
        [InlineData(75000, 1120, 76120)]
        [InlineData(92300, 500, 92800)]
        public void TestCalAmountToBePaid(double balance, double totalIncrease, double expected)
        {
            var sut = new CalculateAnnualAmount();
            var result = sut.CalAmountToBePaid(balance, totalIncrease);
            result.Should().Be(expected);
        }

        public static IEnumerable<object[]> Data = new List<object[]>
        {
            new object[] { 10000, 12, 1, new List<AnnualAmount>
                 {
                     new AnnualAmount{
                        InterestRate = 12,
                        PrincipalAmount = 10000,
                        NumberOfYears = 1,
                        Paid = 11200
                    },
                 }
            },
            new object[] { 10000, 12, 3, new List<AnnualAmount>
                 {
                     new AnnualAmount{
                        InterestRate = 12,
                        PrincipalAmount = 10000,
                        NumberOfYears = 3,
                        Paid = 11200
                    },
                     new AnnualAmount{
                        InterestRate = 12,
                        PrincipalAmount = 11200,
                        NumberOfYears = 3,
                        Paid = 12544
                    },
                     new AnnualAmount{
                        InterestRate = 12,
                        PrincipalAmount = 12544 ,
                        NumberOfYears = 3,
                        Paid = 14049.28
                    },
                 }
            },
            new object[] { 52000, 10, 4, new List<AnnualAmount>
                 {
                     new AnnualAmount{
                        InterestRate = 10,
                        PrincipalAmount = 52000,
                        NumberOfYears = 4,
                        Paid = 57200
                    },
                     new AnnualAmount{
                        InterestRate = 10,
                        PrincipalAmount = 57200,
                        NumberOfYears = 4,
                        Paid = 62920
                    },
                     new AnnualAmount{
                        InterestRate = 10,
                        PrincipalAmount = 62920,
                        NumberOfYears = 4,
                        Paid = 69212
                    },
                     new AnnualAmount{
                        InterestRate = 10,
                        PrincipalAmount = 69212,
                        NumberOfYears = 4,
                        Paid = 76133.2
                    },
                 }
            },
        };
    }
}
