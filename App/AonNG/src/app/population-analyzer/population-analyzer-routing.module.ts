import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { PopulationAnalyzerContainerComponent } from './population-analyzer-container/population-analyzer-container.component';

const routes: Routes = [
  { path: '', component: PopulationAnalyzerContainerComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class PopulationAnalyzerRoutingModule { }
