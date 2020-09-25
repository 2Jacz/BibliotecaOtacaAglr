import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ApiResponse } from 'src/classes/ApiResponse/api-response';
import { Index } from 'src/classes/Home';
import { baseurl } from '../BaseUrl';

@Injectable({
  providedIn: 'root'
})
export class HomeService {
  response: ApiResponse = new ApiResponse();
  viewmodel: Index = new Index();

  constructor(private http: HttpClient) { }

  public GetHomeData() {
    this.http.get<ApiResponse>(baseurl + 'Home/Index').toPromise().then(res => {
      this.response = res;

      if (this.response.estado === 200) {
        this.viewmodel = res.dato as Index;
      }
    });
  }
}
