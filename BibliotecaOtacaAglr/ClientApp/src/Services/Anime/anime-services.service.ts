import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { baseurl } from '../BaseUrl';
import { Anime } from 'src/classes/Animes/Entity/anime';
import { AnimePaginado } from 'src/classes/Animes/ViewModels/anime-paginado';
import { Paginador } from 'src/classes/Otros/paginador';
import { ApiResponse } from 'src/classes/ApiResponse/api-response';

@Injectable({
  providedIn: 'root'
})
export class AnimeService {
  response: ApiResponse; // formato de respuesta de la api
  animes: Anime[]; // lista de animes
  datos: AnimePaginado; // objeto con la informacion
  paginador: Paginador; // configuracion del paginador

  constructor(private http: HttpClient) { }

  getAnimes(busqueda: string, pagina: number) {
    let url = baseurl + 'Home/Index';
    if (busqueda.trim() !== '') {
      url = url + '?buscar=' + busqueda + '&';
    }
    if (pagina !== null) {
      url = url + '?pagina=' + pagina;
    }

    this.http.get<ApiResponse>(url).toPromise().then(res => {
      this.response = res;

      if (this.response.estado === 200) {
        this.paginador = this.response.dato;
        this.animes = this.datos.datos;
        this.paginador = this.datos.pagina;
      }
    });
  }
}
