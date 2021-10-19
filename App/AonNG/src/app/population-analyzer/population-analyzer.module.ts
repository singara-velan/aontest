import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { PopulationAnalyzerRoutingModule } from './population-analyzer-routing.module';
import { PopulationAnalyzerContainerComponent } from './population-analyzer-container/population-analyzer-container.component';
import { PopulationDemographicDetailComponent } from './population-demographic-detail/population-demographic-detail.component';
import { PopulationAnalyzerService } from './population-analyzer.service';
import { SharedModule } from '../shared/shared.module';


@NgModule({
  declarations: [
    PopulationAnalyzerContainerComponent,
    PopulationDemographicDetailComponent
  ],
  providers: [PopulationAnalyzerService],
  imports: [
    CommonModule,
    PopulationAnalyzerRoutingModule,
    SharedModule
  ]
})
export class PopulationAnalyzerModule { }
