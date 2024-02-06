using LoanCalculator.ApiService.LoanCalculator;
using LoanCalculator.Common;
using LoanCalculator.Common.ValueObjects;

namespace LoanCalculator.ApiService.Tests
{
    public class LoanEquatedRepaymentScheduleTests
    {
        [Fact]
        public void RepaymentSchedule_Should_CalculateCorrectly_Scenario1()
        {
            LoanTerms loanTerms = new(
                LoanAmount: new Money(100_000), 
                LoanTenureYears: 10, 
                IndicativeInterestRate: new PercentageRate(7.2M));

            Money expectedEMI = new(1_171.43M);
            Money expectedTotalPaymentsMade = new(140_562.60M);
            Money expectedTotalInterestPaid = new(40_569.57M);
            Money expectedFinalOutstandingPrincipal = new(0);

            LoanEquatedRepaymentSchedule schedule = new(loanTerms);

            //Null should fail the test anyway
            Money actualFinalOutstandingPrincipal = schedule.MonthlyInstallments
                .First(x => x.Month == schedule.MonthlyInstallments.Count)
                .OutstandingPrincipal;

            Assert.Equal(expectedEMI, schedule.EMI);
            Assert.Equal(expectedTotalPaymentsMade, schedule.TotalPaymentsMade);
            Assert.Equal(loanTerms.LoanAmount, schedule.TotalPrincipalPaid);
            Assert.Equal(expectedTotalInterestPaid, schedule.TotalInterestPaid);
            Assert.Equal(loanTerms.LoanTenureYears * 12, schedule.MonthlyInstallments.Count);
            Assert.Equal(expectedFinalOutstandingPrincipal, actualFinalOutstandingPrincipal);
        }

        //TODO: Add more test cases
    }
}