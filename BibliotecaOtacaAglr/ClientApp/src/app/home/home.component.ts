import { Component, OnInit } from '@angular/core';
import { Index } from 'src/classes/Home';
import { HomeService } from 'src/Services/Home/home-services.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  errorMessage: string;
  viewModel: Index = new Index();
  mensajeApi: string;

  constructor(private apiHome: HomeService) { }

  ngOnInit(): void {
    this.apiHome.GetHomeData().subscribe(
      (res) => {
        if (res.estado === 200) {
          this.viewModel = res.dato;
        } else {
          this.mensajeApi = res.mensaje;
        }
      },
      (error) => {
        this.errorMessage = error;
      }
    );
  }

}
