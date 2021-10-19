import { Component, OnInit } from '@angular/core';
import { PopulationAnalyzerService } from '../population-analyzer.service';

@Component({
  selector: 'app-population-analyzer-container',
  templateUrl: './population-analyzer-container.component.html',
  styleUrls: ['./population-analyzer-container.component.scss']
})
export class PopulationAnalyzerContainerComponent implements OnInit {

  public isBusy: boolean = false;

  public countryPopulation: any;
  private selectedState: any;
  constructor(private populationAnalyzerService: PopulationAnalyzerService) { }

  ngOnInit(): void {
    this.initData();
  }

  initData() {
    this.isBusy = true;
    const req = {
      "CountryName": "Japan",
      "NoOfTopStates": 10
    };
    this.populationAnalyzerService.getPopulationByCountry(req).subscribe((resp: any) => {
      this.countryPopulation = resp.countryPopulation;
      this.isBusy = false;
    }, () => {
      this.isBusy = false;
      this.countryPopulation = null;
    });
  }

  setSelectedState(stateData?: any) {
    this.selectedState = stateData;
  }

  getDemographyDetail() {
    return this.selectedState || this.countryPopulation;
  }

  getBgColor(index: number, splitCount: number) {
    const r = 25, g = 118, b =210;
    let colorCode = `rgb(${r},${g},${b})`;
    if(index > 0) {
      index +=1;
      const incremet = (255 - r)*index/(splitCount || 10);
      colorCode = `rgb(${r + incremet},${g + incremet},${b + incremet})`
    }
    return colorCode;
  }

}
