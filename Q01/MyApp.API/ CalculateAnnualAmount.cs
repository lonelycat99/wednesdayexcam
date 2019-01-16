using System.Collections.Generic;
using MyApp.API.Models;

namespace MyApp.API
{
    public class CalculateAnnualAmount
    {
        public IEnumerable<AnnualAmount> CalLoanInterest(double balance, int increase, int years)
        {
            var paidOfYears = new List<AnnualAmount>();
            var totalIncrease = CalIncrease(balance, increase);
            var sumOfMoneyAndIncrease = CalAmountToBePaid(balance, totalIncrease);
            paidOfYears.Add(new AnnualAmount()
            {
                InterestRate = increase,
                PrincipalAmount = balance,
                NumberOfYears = years,
                Paid = sumOfMoneyAndIncrease
            });

            for (int i = 1; i < years; i++)
            {
                totalIncrease = CalIncrease(sumOfMoneyAndIncrease, increase);
                sumOfMoneyAndIncrease = CalAmountToBePaid(sumOfMoneyAndIncrease, totalIncrease);

                paidOfYears.Add(new AnnualAmount()
                {
                    PrincipalAmount = sumOfMoneyAndIncrease - totalIncrease,
                    InterestRate = increase,
                    NumberOfYears = years,
                    Paid = sumOfMoneyAndIncrease
                });
            }
            return paidOfYears;
        }

        public double CalIncrease(double balance, int increase)
        {
            return balance * increase / 100;
        }

        public double CalAmountToBePaid(double balance, double totalIncrease)
        {

            return balance + totalIncrease;
        }
    }
}