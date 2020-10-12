import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { baseurl } from '../BaseUrl';
import { ApiResponse } from 'src/classes/ApiResponse/api-response';
import { Observable } from 'rxjs';
import { AnimeCrear } from 'src/classes/Animes/ViewModels/anime-crear';

const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type': 'multipart/form-data'
  })
};

@Injectable({
  providedIn: 'root'
})
export class AnimeService {
  constructor(private http: HttpClient) { }

  getAnimes(): Observable<ApiResponse> {
    const url = baseurl + 'Animes/Lista';
    return this.http.get<ApiResponse>(url);
  }

  getAnimesFilter(busqueda?: string, pagina?: number): Observable<ApiResponse> {
    const url = baseurl + 'Animes/Lista';
    let params = new HttpParams();

    if (busqueda && busqueda.trim().length > 0) {
      params = params.append('buscar', busqueda);
    }

    if (pagina && pagina > 1) {
      params = params.append('pagina', pagina.toString());
    }
    return this.http.get<ApiResponse>(url, { params: params });
  }

  addAnime(anime: AnimeCrear): Observable<ApiResponse> {
    const url = baseurl + 'Animes/Agregar';
    return this.http.post<ApiResponse>(url, anime);
  }
}
