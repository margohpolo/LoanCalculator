using LoanCalculator.Common;

namespace LoanCalculator.ApiService.LoanCalculator;

/// <summary>
/// May not be necessary for now as there's only 1 Calculation type,
/// but could be refactored in the future for more use cases.
/// </summary>
public class LoanCalculatorService : ILoanCalculatorService
{
    public LoanCalculatorService() { }

    public RepaymentScheduleDto Calculate(LoanTermsDto loanTerms)
        => new LoanEquatedRepaymentSchedule(loanTerms.FromDto())
            .ToDto();
}
