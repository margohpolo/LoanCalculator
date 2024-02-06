import { TestBed } from '@angular/core/testing';

import { LoanCalculationService } from './loan-calculation.service';

describe('LoanCalculationService', () => {
  let service: LoanCalculationService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(LoanCalculationService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
