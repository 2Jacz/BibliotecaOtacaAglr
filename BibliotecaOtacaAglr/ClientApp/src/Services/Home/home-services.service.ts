import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/internal/Observable';
import { ApiResponse } from 'src/classes/ApiResponse/api-response';
import { baseurl } from '../BaseUrl';

@Injectable({
  providedIn: 'root'
})
export class HomeService {
  constructor(private http: HttpClient) { }

  public GetHomeAnimeData(): Observable<ApiResponse> {
    return this.http.get<ApiResponse>(baseurl + 'Home/Anime');
  }

  public GetHomeMangaData(): Observable<ApiResponse> {
    return this.http.get<ApiResponse>(baseurl + 'Home/Manga');
  }
}
