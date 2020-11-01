import { Component, OnInit } from '@angular/core';
import { Anime } from 'src/classes/Animes/Entity/anime';
import { Paginador } from 'src/classes/Otros/paginador';
import { AnimeService } from 'src/Services/Anime/anime-services.service';

@Component({
  selector: 'app-anime-index',
  templateUrl: './anime-index.component.html',
  styleUrls: ['./anime-index.component.css']
})
export class AnimeIndexComponent implements OnInit {
  animes: Anime[] = []; // lista de animes
  paginador: Paginador = new Paginador(); // configuracion del paginador
  errorMessage = ''; // error en caso de fallar
  rangoPaginador: number[] = []; // paginas del paginador
  busqueda = '';
  buscado = '';
  cargando = true;

  constructor(private apiAnime: AnimeService) { }

  ngOnInit(): void {
    this.apiAnime.getAnimes().subscribe(
      (res) => {
        if (res.estado === 200) {
          this.animes = res.dato.datos;
          this.paginador = res.dato.pagina;
          this.rangoPaginadorFiller(this.paginador.paginaInicial, this.paginador.paginaFinal);
        } else {
          this.errorMessage = res.mensaje;
        }

        this.cargando = false;
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
    this.rangoPaginador = [];
    let pagina = paginaInicial;
    while (pagina < paginaFinal) {
      this.rangoPaginador.push(pagina);
      pagina++;
    }
  }

  irAPagina() {
    const pagina = parseInt(prompt('Ingrese una pagina correcta (1-' + this.paginador.paginasTotales + ')', '1'), 10);

    if (pagina != null) {
      if (pagina >= 1 && pagina <= this.paginador.paginasTotales) {
        this.buscarPagina(pagina);
      } else {
        alert('Ingrese una pagina valida (1-' + this.paginador.paginasTotales + ')');
      }
    }

    this.buscado = this.busqueda;
    this.busqueda = '';
  }

  buscarPagina(pagina: number) {
    this.buscado = this.busqueda;
    this.busqueda = '';
    this.cargando = true;

    if (this.busqueda.trim().length <= 0 || pagina !== this.paginador.paginaActual) {
      this.apiAnime.getAnimesFilter(this.buscado, pagina).subscribe(
        (res) => {
          if (res.estado === 200) {
            this.animes = res.dato.datos;
            this.paginador = res.dato.pagina;
            this.rangoPaginadorFiller(this.paginador.paginaInicial, this.paginador.paginaFinal);
          } else {
            this.errorMessage = res.mensaje;
          }

          this.cargando = false;
        }, (error) => {
          this.errorMessage = error;
        });
    }
  }

  pagAnterior() {
    this.buscarPagina((this.paginador.paginaActual - 1));
  }

  pagSiguiente() {
    this.buscarPagina((this.paginador.paginaActual + 1));
  }

  placeholder(): string {
    if (this.buscado.trim().length > 0) {
      return this.buscado;
    } else {
      return 'Ingrese un nombre a buscar';
    }
  }
}
