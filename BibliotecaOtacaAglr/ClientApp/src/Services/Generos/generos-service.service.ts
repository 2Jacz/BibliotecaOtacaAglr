import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ApiResponse } from 'src/classes/ApiResponse/api-response';
import { baseurl } from '../BaseUrl';

@Injectable({
  providedIn: 'root'
})
export class GenerosService {

  constructor(private http: HttpClient) { }

  public obtenerGeneros(): Observable<ApiResponse> {
    const url = baseurl + 'Generos/ListaAsignar';
    return this.http.get<ApiResponse>(url);
  }
}
