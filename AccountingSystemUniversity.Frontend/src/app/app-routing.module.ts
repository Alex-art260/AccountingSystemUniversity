import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { BuildingComponent } from './components/buildings/building.component';
import { AuditoriumsComponent } from './components//auditoriums/auditoriums.component';

const routes: Routes = [
  { path: 'buildings', component: BuildingComponent },
  { path: 'auditoriums', component: AuditoriumsComponent },
  { path: '', redirectTo: '/buildings', pathMatch: 'full' } // Перенаправление на 'buildings' по умолчанию
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }