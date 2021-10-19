import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpService } from '../core/services/http.service';
import { Constants } from '../shared/constants/constants';

@Injectable()
export class PopulationAnalyzerService {

  constructor(private httpService: HttpService) { }

  getPopulationByCountry(req: any) {
    if (environment.isEnableFakeBackend) {
      return this.httpService.httpGet(Constants.API.FAKE_BACKEND, null, false);
    } else {
      return this.httpService.httpPost(Constants.API.COUNTRY_POPULATION, req);
    }
  }
}
