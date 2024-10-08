import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms'; // Добавьте FormsModule
import { HttpClientModule } from '@angular/common/http'; // Добавьте HttpClientModule
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BuildingComponent } from './components/buildings/building.component';
import { AuditoriumsComponent } from './components/auditoriums/auditoriums.component';
import { BuildingService } from './services/building.service';
import { AuditoriumService } from './services/auditorium.service';

@NgModule({
  declarations: [
    AppComponent,
    BuildingComponent,
    AuditoriumsComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule
  ],
  providers: [BuildingService, AuditoriumService],
  bootstrap: [AppComponent]
})
export class AppModule { }