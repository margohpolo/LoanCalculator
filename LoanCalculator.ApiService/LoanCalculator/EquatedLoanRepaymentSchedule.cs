using LoanCalculator.Common;
using LoanCalculator.Common.ValueObjects;

namespace LoanCalculator.ApiService.LoanCalculator;

/// <summary>
/// This Schedule will (i) calculate the EMI, then 
/// (ii) Calculate each MonthlyInterestPayment, then 
/// (iii) each MonthlyPrincipalPayback, and finally 
/// (iv) each PrincipalBalanceOwed.
/// </summary>
public class LoanEquatedRepaymentSchedule
{
    /// <summary>
    /// Collection of Equated Monthly Installments.
    /// </summary>
    public HashSet<EquatedMonthlyInstallment> MonthlyInstallments = [];

    /// <summary>
    /// Formula: Principal * (  ( r * ((1+r)^n) ) / ( ((1+r)^n) - 1 )  ).
    /// </summary>
    public Money EMI { get; init; }

    //TODO: Implement LINQ overrides for ValueObjects.
    //ALSO, aside from using in Unit Tests, maybe this can be
    //done on the FE instead...?
    public Money TotalPaymentsMade => new Money(
        MonthlyInstallments.Sum(x => x.MonthlyInstallment.Value));

    public Money TotalPrincipalPaid => new Money(
        MonthlyInstallments.Sum(x => x.PrincipalPortion.Value));

    public Money TotalInterestPaid => new Money(
        MonthlyInstallments.Sum(x => x.InterestPortion.Value));



    private Money _principal { get; init; }
    private PercentageRate _interestRateAnnual { get; init; }
    private int _numberOfMonthlyPayments { get; init; }

    //TODO: Revisit design. Doing all the work in constructor may not be a good idea...
    public LoanEquatedRepaymentSchedule(LoanTerms loanTerms)
    {
        _principal = loanTerms.LoanAmount;
        _interestRateAnnual = loanTerms.IndicativeInterestRate;
        _numberOfMonthlyPayments = loanTerms.LoanTenureYears * 12;
        
        EMI = CalculateEMI();
        MonthlyInstallments = GetMonthlyInstallments();
    }

    #region Calculation Helpers
    private PercentageRate interestRateMonthly => _interestRateAnnual / 12;
    /// <summary>
    /// `(1+r)^n` portion of the calculations.
    /// </summary>
    private PercentageRate interestRateMonthlyPlusOneThenExponentN
        => ((interestRateMonthly/100) + 1).ToThePowerOf(_numberOfMonthlyPayments);
    private Money CalculateEMI()
        => _principal * (
                (interestRateMonthly * interestRateMonthlyPlusOneThenExponentN) / 
                (interestRateMonthlyPlusOneThenExponentN - 1)
            );

    private HashSet<EquatedMonthlyInstallment> GetMonthlyInstallments()
    {
        HashSet<EquatedMonthlyInstallment> installmentsSet = [];

        int monthCount = 0;
        Money principalRemaining = _principal;

        while (monthCount < _numberOfMonthlyPayments)
        {
            bool isFinalPayment = EMI > principalRemaining;
            Money monthlyInstallment = (isFinalPayment) ? principalRemaining : EMI;
            Money interestPortion = principalRemaining * interestRateMonthly;
            Money principalPortion = (isFinalPayment) ? principalRemaining : monthlyInstallment - interestPortion;

            EquatedMonthlyInstallment newInstallment = new(
                Month: ++monthCount, 
                MonthlyInstallment: monthlyInstallment,
                InterestPortion: interestPortion,
                PrincipalPortion: principalPortion,
                OutstandingPrincipal: principalRemaining -= principalPortion);

            installmentsSet.Add(newInstallment);
        }

        return installmentsSet;
    }

    #endregion
}
