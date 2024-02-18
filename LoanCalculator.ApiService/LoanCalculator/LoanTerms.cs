using LoanCalculator.Common.ValueObjects;

namespace LoanCalculator.ApiService.LoanCalculator;



/// <summary>
/// Record type.
/// </summary>
/// <param name="LoanAmount"></param>
/// <param name="LoanTenureYears"></param>
/// <param name="IndicativeInterestRate"></param>
public record LoanTerms(Money LoanAmount, int LoanTenureYears, PercentageRate IndicativeInterestRate);