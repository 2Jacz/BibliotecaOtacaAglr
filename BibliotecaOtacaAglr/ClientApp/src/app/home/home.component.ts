import { Component, OnInit } from '@angular/core';
import { ApiResponse } from 'src/classes/ApiResponse/api-response';
import { Index } from 'src/classes/Home';
import { HomeService } from 'src/Services/Home/home-services.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  response: ApiResponse;
  viewmodel: Index;

  constructor(private apiHome: HomeService) {
    apiHome.GetHomeData().subscribe(response => {
      this.response = response;

      if (response.Estado === 200) {
        this.viewmodel.AnimeUltimos10EpsAgregados = this.response.Datos.AnimeUltimos10EpsAgregados;
        this.viewmodel.MangaUltimos10CapsAgregados = this.response.Datos.MangaUltimos10CapsAgregados;
        this.viewmodel.Ultimos7AnimesAgregados = this.response.Datos.Ultimos7AnimesAgregados;
        this.viewmodel.Ultimos7MangasAgregados = this.response.Datos.Ultimos7MangasAgregados;
      }
    });
  }

  ngOnInit(): void {
  }

}
