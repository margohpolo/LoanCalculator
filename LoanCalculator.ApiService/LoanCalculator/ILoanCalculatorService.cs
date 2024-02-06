using LoanCalculator.Common;

namespace LoanCalculator.ApiService.LoanCalculator;

public interface ILoanCalculatorService
{
    RepaymentScheduleDto Calculate(LoanTermsDto loanTerms);
}
