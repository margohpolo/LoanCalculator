import { EquatedMonthlyInstallment } from "./EquatedMonthlyInstallment";

export interface RepaymentSchedule {
  equalMonthlyInstallment : string;
  totalPaymentsMade : string;
  totalPrincipalPaid : string;
  totalInterestPaid : string;
  monthlyInstallments : EquatedMonthlyInstallment[];
}
