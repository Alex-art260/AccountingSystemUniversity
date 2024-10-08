import { Component } from '@angular/core';
import { RouterModule } from '@angular/router';
import { CommonModule } from '@angular/common';
import { BuildingComponent } from './components/buildings/building.component'; // Импортируйте BuildingsComponent

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
  standalone: true,
  imports: [RouterModule, CommonModule, BuildingComponent] // Добавьте BuildingsComponent в imports
})
export class AppComponent {
  title = 'my-app';
}