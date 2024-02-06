import { CommonModule } from '@angular/common';
import { Component, OnDestroy, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { MatTableModule } from '@angular/material/table';
import { LoanCalculationService } from './loan-calculation.service';
import { RepaymentSchedule } from '../interfaces/RepaymentSchedule';
import { LoanTerms } from '../interfaces/LoanTerms';
import { Observable, Subscription, map, tap } from 'rxjs';

@Component({
  selector: 'app-loan-form',
  standalone: true,
  imports: [CommonModule, FormsModule, ReactiveFormsModule,
    MatInputModule, MatSelectModule, MatButtonModule,
    MatCardModule,
    MatTableModule],
  templateUrl: './loan-form.component.html',
  styleUrl: './loan-form.component.css'
})
export class LoanFormComponent implements OnInit, OnDestroy {
  submitted = false;
  loanForm!: FormGroup;
  loanTerms: LoanTerms;
  repaymentSchedule : RepaymentSchedule;
  subscription : Subscription;
  responseData$: Observable<RepaymentSchedule>;
  displayedColumns = ['Month','MonthlyInstallment','InterestPortion','PrincipalPortion','OutstandingPrincipal'];

  constructor(
    private fb: FormBuilder,
    private calculationSvc : LoanCalculationService
  )
  {
  }
//^\d+$ | ^(?:\d+|\d+\.\d+)$
  ngOnInit(): void {
    this.loanForm = this.fb.group({
      loanAmount: new FormControl('', Validators.compose([Validators.required, Validators.min(1000), Validators.max(10000000), Validators.pattern("^[0-9]+(\.[0-9]+)?$")])),
      loanTenureYears: new FormControl('', Validators.compose([Validators.required, Validators.min(1), Validators.max(30), Validators.pattern("[0-9]{1,2}")])),
      indicativeInterestRate: new FormControl('', Validators.compose([Validators.required, Validators.min(2.5), Validators.max(30), Validators.pattern("^[0-9]+(\.[0-9]+)?$")]))
    });

    // this.loanForm.valueChanges.subscribe(console.log);
  }


  get loanFormControl() {
    return this.loanForm.controls;
  }

  onSubmit(){
    if (this.loanForm.valid){
      // alert('Form is valid!');
      const formValues = this.loanForm.value;
      this.loanTerms = {
        LoanAmount: parseFloat(formValues.loanAmount),
        LoanTenureYears: parseInt(formValues.loanTenureYears),
        IndicativeInterestRate: parseFloat(formValues.indicativeInterestRate)
      };
      console.log('loanTerms: ' + JSON.stringify(this.loanTerms));
      this.subscription = this.calculationSvc
        .GetRepaymentSchedule$(this.loanTerms)
        .subscribe(result => {
          this.repaymentSchedule = result;
        });

      this.submitted = true;
    }
  }

  ngOnDestroy(): void {
    this.subscription.unsubscribe();
  }
}
