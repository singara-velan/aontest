import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  { path: 'population', loadChildren: () => import('./population-analyzer/population-analyzer.module').then(m => m.PopulationAnalyzerModule) },
  { path: '', redirectTo: 'population', pathMatch: 'full' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
