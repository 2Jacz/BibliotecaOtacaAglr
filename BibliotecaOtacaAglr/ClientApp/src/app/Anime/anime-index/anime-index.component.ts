import { Component, OnInit } from '@angular/core';
import { AnimeService } from 'src/Services/Anime/anime-services.service';

@Component({
  selector: 'app-anime-index',
  templateUrl: './anime-index.component.html',
  styleUrls: ['./anime-index.component.css']
})
export class AnimeIndexComponent implements OnInit {

  constructor(private apiAnime: AnimeService) { }

  ngOnInit(): void {
    this.apiAnime.getAnimes();
  }
}
