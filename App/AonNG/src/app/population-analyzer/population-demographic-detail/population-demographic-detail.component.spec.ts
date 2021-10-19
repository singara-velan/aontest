import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PopulationDemographicDetailComponent } from './population-demographic-detail.component';

describe('PopulationDemographicDetailComponent', () => {
  let component: PopulationDemographicDetailComponent;
  let fixture: ComponentFixture<PopulationDemographicDetailComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PopulationDemographicDetailComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(PopulationDemographicDetailComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
