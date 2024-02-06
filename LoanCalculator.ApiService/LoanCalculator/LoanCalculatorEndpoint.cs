using FastEndpoints;
using LoanCalculator.Common;

namespace LoanCalculator.ApiService.LoanCalculator;

public class LoanCalculatorEndpoint : Endpoint<LoanTermsDto, RepaymentScheduleDto>
{
    private readonly ILoanCalculatorService _loanCalculatorService;

    public LoanCalculatorEndpoint(ILoanCalculatorService loanCalculatorService)
    {
        _loanCalculatorService = loanCalculatorService;
    }

    public override void Configure()
    {
        Post("/calculateloan");
        AllowAnonymous();
    }

    public override async Task HandleAsync(LoanTermsDto request, CancellationToken ct)
    {
        await SendOkAsync(_loanCalculatorService.Calculate(request), ct);
    }
}
