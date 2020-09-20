import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { HomeComponent } from './home/home.component';
import { AnimeIndexComponent } from './Anime/anime-index/anime-index.component';
import { PageNotFoundComponent } from './page-not-found/page-not-found.component';

const rutas: Routes = [
  { path: '', redirectTo: '/Inicio', pathMatch: 'full' },
  { path: 'Inicio', component: HomeComponent },
  { path: 'Animes', component: AnimeIndexComponent },
  { path: '**', component: PageNotFoundComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(rutas)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
