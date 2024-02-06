using LoanCalculator.Common.ValueObjects;

namespace LoanCalculator.Common
{
    /// <summary>
    /// Incoming Request of LoanTerms.
    /// </summary>
    /// <param name="LoanAmount"></param>
    /// <param name="LoanTenureYears"></param>
    /// <param name="IndicativeInterestRate"></param>
    public record LoanTermsDto(decimal LoanAmount, int LoanTenureYears, decimal IndicativeInterestRate);

    /// <summary>
    /// Record type.
    /// </summary>
    /// <param name="LoanAmount"></param>
    /// <param name="LoanTenureYears"></param>
    /// <param name="IndicativeInterestRate"></param>
    public record LoanTerms(Money LoanAmount, int LoanTenureYears, PercentageRate IndicativeInterestRate);

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

    /// <summary>
    /// DTO for EquatedMonthlyInstallment.
    /// </summary>
    /// <param name="Month"></param>
    /// <param name="MonthlyInstallment"></param>
    /// <param name="Principal"></param>
    /// <param name="Interest"></param>
    /// <param name="OutstandingBalance"></param>
    public record EquatedMonthlyInstallmentDto(int Month, string MonthlyInstallment,
        string InterestPortion, string PrincipalPortion, string OutstandingPrincipal);

    public record RepaymentScheduleDto(string EqualMonthlyInstallment, string TotalPaymentsMade, string TotalPrincipalPaid,
        string TotalInterestPaid, HashSet<EquatedMonthlyInstallmentDto> MonthlyInstallments);

    /// <summary>
    /// Record type.
    /// </summary>
    /// <param name="Date"></param>
    /// <param name="TemperatureC"></param>
    /// <param name="Summary"></param>
    public record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
    {
        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
    }
}
