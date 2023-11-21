import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ListPlayersComponent } from './list-players/list-players.component';
import { ListTeamsComponent } from './list-teams/list-teams.component';
import { AddPlayersComponent } from './add-players/add-players.component';
import { ReactiveFormsModule } from '@angular/forms';
import { PlayerComponent } from './player/player.component';
import { LoginComponent } from './login/login.component';
import { HomeComponent } from './home/home.component';
@NgModule({
  declarations: [
    AppComponent,
    ListPlayersComponent,
    ListTeamsComponent,
    AddPlayersComponent,
    PlayerComponent,
    LoginComponent,
    HomeComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    ReactiveFormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
