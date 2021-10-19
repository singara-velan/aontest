import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PopulationAnalyzerContainerComponent } from './population-analyzer-container.component';

describe('PopulationAnalyzerContainerComponent', () => {
  let component: PopulationAnalyzerContainerComponent;
  let fixture: ComponentFixture<PopulationAnalyzerContainerComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PopulationAnalyzerContainerComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(PopulationAnalyzerContainerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
