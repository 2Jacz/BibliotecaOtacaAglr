import { Component, OnInit } from '@angular/core';
import { MaxLengthValidator } from '@angular/forms';
import { AnimeService } from 'src/Services/Anime/anime-services.service';

@Component({
  selector: 'app-anime-index',
  templateUrl: './anime-index.component.html',
  styleUrls: ['./anime-index.component.css']
})
export class AnimeIndexComponent implements OnInit {

  constructor(private apiAnime: AnimeService) { }
  busqueda: string; // nombre a buscar
  pagina: number;

  ngOnInit(): void {
    this.apiAnime.getAnimes('', 1);
  }

  bucarPagina() {
    // tslint:disable-next-line: prefer-const
    let pagenumber = parseInt(prompt('Ir a la pagina: (1-' + this.apiAnime.paginador.paginasTotales + ')', '1'), 10);

    if (pagenumber != null) {
      if (pagenumber >= 1 && pagenumber <= this.apiAnime.paginador.paginasTotales) {
        this.apiAnime.getAnimes(this.busqueda, this.pagina);
      } else {
        alert('Ingrese una pagina valida (1-' + this.apiAnime.paginador.paginasTotales + ')');
      }
    }
  }

}
