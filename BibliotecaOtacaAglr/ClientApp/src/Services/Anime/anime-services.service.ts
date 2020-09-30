import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { baseurl } from '../BaseUrl';
import { Anime } from 'src/classes/Animes/Entity/anime';
import { AnimePaginado } from 'src/classes/Animes/ViewModels/anime-paginado';
import { Paginador } from 'src/classes/Otros/paginador';
import { ApiResponse } from 'src/classes/ApiResponse/api-response';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AnimeService {
  public animes: Anime[] = []; // lista de animes
  public paginador: Paginador = new Paginador(); // configuracion del paginador
  public errorMessage: any; // error en caso de fallar
  public rangoPaginador: number[] = []; // paginas del paginador

  constructor(private http: HttpClient) { }

  getAnimes() {
    const url = baseurl + 'Animes/Lista';
    this.http.get<ApiResponse>(url).subscribe(
      (res) => {
        console.log(res);
        if (res.estado && res.estado === 200) {
          this.animes = res.dato.datos;
          this.paginador = res.dato.pagina;

          this.rangoPaginadorFiller(this.paginador.paginaInicial, this.paginador.paginaFinal);
        } else {
          this.errorMessage = res.mensaje;
        }
      }, (error) => {
        this.errorMessage = error;
      });

      console.log(this.paginador);
      console.log(this.rangoPaginador);
  }

  getAnimesFilter(busqueda: string, pagina: number) {
    const url = baseurl + 'Anime/Lista';
    const params = new HttpParams().set('busqueda', busqueda).set('pagina', pagina.toString());

    this.http.get<ApiResponse>(url, { params }).subscribe(
      (res) => {
        if (res.estado && res.estado === 200) {
          this.animes = res.dato.datos;
          this.paginador = res.dato.pagina;

          this.rangoPaginadorFiller(this.paginador.paginaInicial, this.paginador.paginaFinal);
        } else {
          this.errorMessage = res.mensaje;
        }
      }, (error) => {
        this.errorMessage = error;
      });
  }

  /**
   * Ajusta el rango que abarcara el paginado
   * @param paginaInicial primera pagina
   * @param paginaFinal ultima pagina
   */
  private rangoPaginadorFiller(paginaInicial: number, paginaFinal: number) {
    let pagina = paginaInicial;
    while (pagina < paginaFinal) {
      this.rangoPaginador.push(pagina);
      pagina++;
    }
  }
}
