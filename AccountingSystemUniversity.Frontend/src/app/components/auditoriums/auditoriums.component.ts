import { Component, OnInit } from '@angular/core';
import { Auditorium } from '../../model/auditorium.model'; 
import { BuildingDto } from '../../model/buildingDto.model';
import { AuditoriumService } from '../../services/auditorium.service'; 
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common'; 
import { ApiService } from '../../services/api.service'; 
import { TypeRoomDto } from '../../model/typeRoomDto.model';
import { ChangeDetectorRef } from '@angular/core';
import { concatMap, tap } from 'rxjs/operators';
import { Observable } from 'rxjs'

@Component({
  selector: 'app-auditoriums',
  templateUrl: './auditorium.component.html',
  styleUrls: ['./auditoriums.component.css'],
  standalone: true,
  imports: [
    FormsModule,
    CommonModule 
  ]
})
export class AuditoriumsComponent implements OnInit {
  auditoriums: Auditorium[] = [];
  isLoading = false;
  showAddForm = false;
  editingAuditorium: Auditorium | null = null; // Добавьте модель Auditorium
  newAuditorium: Auditorium = { // Добавьте модель Auditorium
    id: 0,
    name: '',
    capacity: 0,
    floor: 0,
    number: 0,
    buildingId: 0,
    typeRoomId: 0,
    buildingName: '', // Добавьте BuildingName
    typeRoomName: '', // Добавьте TypeRoomName
  };
  buildings:  BuildingDto[] = [];
  rooms: TypeRoomDto[] =[];

  constructor(private auditoriumService: AuditoriumService, private apiService: ApiService, private changeDetectorRef: ChangeDetectorRef) { }

  ngOnInit() {
    this.isLoading = true;
    this.getAuditoriums()
      .pipe(
        concatMap(() => this.getBuildings().pipe(
          tap((buildings: BuildingDto[]) => { // Указываем тип для buildings
            this.buildings = buildings;
          })
        )),
        concatMap(() => this.getTypeRooms())
      )
      .subscribe(
        (rooms) => {
          this.isLoading = false;
          this.rooms = rooms;
        },
        (error: Error) => {
          console.error('Ошибка получения данных:', error);
          this.isLoading = false;
        }
      );
  }
  getTypeRooms(): Observable<TypeRoomDto[]> {
    return this.auditoriumService.getTypeRooms();
  }

  getBuildings(): Observable<BuildingDto[]> {
    return this.auditoriumService.getBuildings();
  }

  getAuditoriums(): Observable<Auditorium[]> {
    return this.auditoriumService.getAuditoriums();
  }

  addAuditorium(): void {
    this.showAddForm = !this.showAddForm; // Переключаем видимость формы
    if (this.showAddForm) {
      this.newAuditorium = {
        id: 0,
        name: '',
        capacity: 0,
        floor: 0,
        number: 0,
        buildingId: 0,
        typeRoomId: 0,
        buildingName: '', // Добавьте BuildingName
        typeRoomName: '', // Добавьте TypeRoomName
      };
    }
  }

  saveAuditorium(): void { // Добавьте метод saveAuditorium
    if (this.editingAuditorium) {
      // Обновление существующей аудитории
      this.auditoriumService.updateAuditorium(this.editingAuditorium).subscribe(
        (updatedAuditorium) => {
          this.updateAuditoriumList(updatedAuditorium);
          this.editingAuditorium = null;
          this.showAddForm = false; 
          this.getAuditoriums();
        },
        (error) => {
          console.error('Ошибка обновления аудитории:', error);
        }
      );
    } else {
      // Добавление новой аудитории
      this.auditoriumService.addAuditorium(this.newAuditorium).subscribe(
        (newAuditorium) => {
          this.auditoriums.push(newAuditorium);
          this.newAuditorium = {
            id: 0,
            name: '',
            capacity: 0,
            floor: 0,
            number: 0,
            buildingId: 0,
            typeRoomId: 0,
            buildingName: '', // Добавьте BuildingName
            typeRoomName: '', // Добавьте TypeRoomName
          };
          this.showAddForm = false;
          this.getAuditoriums();
  
        },
        (error) => {
          console.error('Ошибка добавления аудитории:', error);
        }
      );
    }
  }

  editAuditorium(auditorium: Auditorium): void {
    console.log("BuildingId:", auditorium.buildingId); // Добавьте метод editAuditorium
    this.editingAuditorium = { ...auditorium };

    this.editingAuditorium.buildingId = auditorium.buildingId;
    this.editingAuditorium.typeRoomId = auditorium.typeRoomId;


    setTimeout(() => {
      
    }, 0);
  }

  deleteAuditorium(id: number): void { // Добавьте метод deleteAuditorium
    this.auditoriumService.deleteAuditorium(id).subscribe(
      () => {
        this.auditoriums = this.auditoriums.filter(auditorium => auditorium.id !== id);
      },
      (error) => {
        console.error('Ошибка удаления аудитории:', error);
      }
    );
  }

  private updateAuditoriumList(updatedAuditorium: Auditorium): void { // Добавьте метод updateAuditoriumList
    const index = this.auditoriums.findIndex(auditorium => auditorium.id === updatedAuditorium.id);
    if (index !== -1) {
      this.auditoriums[index] = updatedAuditorium;
    }
  }

}