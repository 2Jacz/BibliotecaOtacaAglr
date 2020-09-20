import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ApiResponse } from 'src/classes/ApiResponse/api-response';
import { baseurl } from '../BaseUrl';

@Injectable({
  providedIn: 'root'
})
export class HomeService {
  url = baseurl + 'Home';

  constructor(private http: HttpClient) { }

  public GetHomeData(): Observable<ApiResponse> {
    return this.http.get<ApiResponse>(this.url);
  }
}
