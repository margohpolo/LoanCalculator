using LoanCalculator.Common;
using LoanCalculator.Common.ValueObjects;

namespace LoanCalculator.ApiService.LoanCalculator
{
    public static class ContractsMapper
    {
        public static LoanTerms FromDto(this LoanTermsDto loanTermsDto)
            => new(
                LoanAmount: new Money(loanTermsDto.LoanAmount),
                LoanTenureYears: loanTermsDto.LoanTenureYears,
                IndicativeInterestRate: new PercentageRate(loanTermsDto.IndicativeInterestRate));

        /// <summary>
        /// Map LoanEquatedRepaymentSchedule to its respective DTO.
        /// </summary>
        /// <param name="scheduleClass"></param>
        /// <returns></returns>
        public static RepaymentScheduleDto ToDto(this LoanEquatedRepaymentSchedule scheduleClass)
            => new(
                EqualMonthlyInstallment: scheduleClass.EMI.ToString(),
                TotalPaymentsMade: scheduleClass.TotalPaymentsMade.ToString(),
                TotalPrincipalPaid: scheduleClass.TotalPrincipalPaid.ToString(),
                TotalInterestPaid: scheduleClass.TotalInterestPaid.ToString(),
                MonthlyInstallments: scheduleClass.MonthlyInstallments.ToDtoCollection());

        private static HashSet<EquatedMonthlyInstallmentDto> ToDtoCollection(this HashSet<EquatedMonthlyInstallment> installmentSet)
        {
            HashSet<EquatedMonthlyInstallmentDto> newDtoSet = [];
            
            foreach (EquatedMonthlyInstallment installment in installmentSet)
            {
                newDtoSet.Add(installment.ToDto());
            }
            return newDtoSet;
        }

        private static EquatedMonthlyInstallmentDto ToDto(this EquatedMonthlyInstallment installment)
            => new(
                Month: installment.Month,
                MonthlyInstallment: installment.MonthlyInstallment.ToString(),
                InterestPortion: installment.InterestPortion.ToString(),
                PrincipalPortion: installment.PrincipalPortion.ToString(),
                OutstandingPrincipal: installment.OutstandingPrincipal.ToString());
    }
}
