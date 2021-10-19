import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class HttpService {

  constructor(private http: HttpClient) {   
  }

  httpGet(url: string, params: any, paramIsObject: boolean) {
    let requestParam;
    if (params && paramIsObject) {
      requestParam = new HttpParams({ fromObject: params });
    } else {
      requestParam = new HttpParams({ fromObject: params })
    }
    return this.http.get(url, {params})
  }

  httpPost(url: string, param: any) {
    const apiEndPoint = `${environment.apiBaseUrl}${url}`;
    return this.http.post(apiEndPoint, param);
  }

}
