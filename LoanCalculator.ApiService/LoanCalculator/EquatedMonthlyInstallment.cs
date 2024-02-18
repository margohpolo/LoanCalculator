using LoanCalculator.Common.ValueObjects;

namespace LoanCalculator.ApiService.LoanCalculator;



/// <summary>
/// Strongly-typed Monthly Installment for LoanRepaymentSchedule.
/// </summary>
/// <param name="Month"></param>
/// <param name="MonthlyInstallment"></param>
/// <param name="Principal"></param>
/// <param name="Interest"></param>
/// <param name="OutstandingBalance"></param>
public record EquatedMonthlyInstallment(int Month, Money MonthlyInstallment,
    Money InterestPortion, Money PrincipalPortion, Money OutstandingPrincipal);