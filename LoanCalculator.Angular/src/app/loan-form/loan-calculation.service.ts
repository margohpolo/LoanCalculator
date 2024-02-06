import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { RepaymentSchedule } from '../interfaces/RepaymentSchedule';
import { LoanTerms } from '../interfaces/LoanTerms';
import { Observable, catchError, map, throwError } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class LoanCalculationService {
  private schedule : RepaymentSchedule;
  constructor(private http: HttpClient) { }

  public GetRepaymentSchedule$(terms: LoanTerms) : Observable<RepaymentSchedule> {
    return this.http.post<RepaymentSchedule>('api/calculateloan', terms)
      .pipe(map(result => { return result }),
        catchError(this.handleError));
  }

  private handleError(error: any): Observable<any> {
    console.error('Error encountered: ', error);
    return throwError(() => error);
  }
}
