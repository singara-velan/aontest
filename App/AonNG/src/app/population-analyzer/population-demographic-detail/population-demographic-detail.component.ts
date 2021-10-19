import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-population-demographic-detail',
  templateUrl: './population-demographic-detail.component.html',
  styleUrls: ['./population-demographic-detail.component.scss']
})
export class PopulationDemographicDetailComponent implements OnInit {

  @Input() demography: any;
  @Input() country!: string;

  constructor() { }

  ngOnInit(): void {
  }

}
