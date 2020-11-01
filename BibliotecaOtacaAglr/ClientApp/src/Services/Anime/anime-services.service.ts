import { HttpClient, HttpEvent, HttpHeaders, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { baseurl } from '../BaseUrl';
import { ApiResponse } from 'src/classes/ApiResponse/api-response';
import { Observable } from 'rxjs';
import { AnimeCrear } from 'src/classes/Animes/ViewModels/anime-crear';

const httpOptions = new HttpHeaders({
    'Content-Type': 'multipart/form-data',
    // 'Authorization': 'bearer ' + ''
  });

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
    const newAnime = new FormData();
    newAnime.append('nombre', anime.nombre);
    newAnime.append('descripcion', anime.descripcion);
    newAnime.append('fecha_publicacion', anime.fecha_publicacion.toLocaleDateString());
    newAnime.append('numero_episodios', anime.numero_episodios.toString());
    newAnime.append('portada', anime.portada);


    for (let index = 0; index < anime.generosActivos.length; index++) {
      // tslint:disable-next-line: forin
      for (const key in anime.generosActivos[index]) {
        if (typeof (anime.generosActivos[index][key]) === 'object') {
          // tslint:disable-next-line: forin
          for (const subKey in anime.generosActivos[index][key]) {
            const a = `generosActivos[${index}].${key}.${subKey}`;
            const b = anime.generosActivos[index][key][subKey];
            newAnime.append(a, b);
          }
        } else {
          const a = `generosActivos[${index}].${key}`;
          const b = anime.generosActivos[index][key];
          console.log({ campo: a, dato: b });
        }
      }
    }

    return this.http.post<ApiResponse>(url, newAnime, { headers: httpOptions });
  }
}
/*
  [generosActivos][0][activo]: true,
  [generosActivos][0][genero][generoId]: 1,
  [generosActivos][0][genero][nombre]: "Accion",
*/
