import { TestBed } from '@angular/core/testing';

import { PopulationAnalyzerService } from './population-analyzer.service';

describe('PopulationAnalyzerService', () => {
  let service: PopulationAnalyzerService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(PopulationAnalyzerService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
