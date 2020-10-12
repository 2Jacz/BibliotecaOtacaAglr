import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';

import { AppComponent } from './app.component';
import { NavBarComponent } from './nav-bar/nav-bar.component';
import { AppRoutingModule } from './app-routing.module';
import { HomeComponent } from './home/home.component';
import { AnimeIndexComponent } from './Anime/anime-index/anime-index.component';
import { PageNotFoundComponent } from './page-not-found/page-not-found.component';
import { ErrorHandlerService } from 'src/Services/ErrorHandler/error-handler-service.service';
import { AnimeAgregarComponent } from './Anime/anime-agregar/anime-agregar.component';
import { MaterialModule } from './app-material-module';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    AnimeIndexComponent,
    PageNotFoundComponent,
    NavBarComponent,
    AnimeAgregarComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    CommonModule,
    HttpClientModule,
    FormsModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    ReactiveFormsModule,
    MaterialModule
  ],
  providers: [{
    provide: HTTP_INTERCEPTORS,
    useClass: ErrorHandlerService,
    multi: true
  }],
  bootstrap: [AppComponent]
})
export class AppModule { }
