import { Component, OnInit } from '@angular/core';
import { HomeService } from 'src/Services/Home/home-services.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  constructor(private apiHome: HomeService) { }

  ngOnInit(): void {
    this.apiHome.GetHomeData();
    console.log(this.apiHome.viewmodel);
  }

}
