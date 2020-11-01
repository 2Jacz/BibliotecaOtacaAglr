import { Component, OnInit } from '@angular/core';
import { HomeAnime } from 'src/classes/Home';
import { HomeService } from 'src/Services/Home/home-services.service';
import { DomSanitizer } from '@angular/platform-browser';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  errorMessage: string;
  homeAnimes: HomeAnime = new HomeAnime();
  cargando: boolean;

  constructor(private apiHome: HomeService, private sanitizer: DomSanitizer) { }

  ngOnInit(): void {
    this.cargarIndex();
  }

  cargarIndex() {
    this.cargando = true;
    this.apiHome.GetHomeAnimeData().subscribe(
      (res) => {
        if (res.estado === 200) {
          this.homeAnimes = res.dato;
        } else {
          this.errorMessage = res.mensaje;
        }
        this.cargando = false;
      },
      (error) => {
        this.errorMessage = error;
      }
    );
  }

  loadImage(imageArray) {
    return this.sanitizer.bypassSecurityTrustResourceUrl('data:image/*;base64,' + imageArray);;
  }
}
