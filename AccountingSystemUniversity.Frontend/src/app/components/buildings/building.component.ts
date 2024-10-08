import { Component, OnInit, ChangeDetectorRef } from '@angular/core';
import { BuildingService } from '../../services/building.service'
import { BuildingDto } from '../../model/building.model';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';

@Component({
  selector: 'app-buildings',
  standalone: true,
  imports: [CommonModule, RouterModule, FormsModule],
  templateUrl: './building.component.html',
  styleUrls: ['./building.component.css']
})
export class BuildingComponent implements OnInit {
  title = 'AccountingSystemUniversity.Frontend';
  buildings: BuildingDto[] = [];
  isLoading = true;
  showAddForm = false;
  editingBuilding: BuildingDto | null = null;
  newBuilding: BuildingDto = {
    id: 0,
    name: '',
    address: '',
    floor: '',
    other: ''
  };

  constructor(private buildingService: BuildingService, private changeDetectorRef: ChangeDetectorRef) {}

  ngOnInit() {
    this.getBuildings();
  }

  getBuildings() {
    this.isLoading = true;
    this.buildingService.getBuildings().subscribe(
      (buildings) => {
        this.buildings = buildings;
        this.isLoading = false;
      },
      (error) => {
        console.error('Ошибка при получении списка корпусов:', error);
        this.isLoading = false;
      }
    );
  }

  addBuilding() {
    this.showAddForm = !this.showAddForm; // Переключаем видимость формы
    if (this.showAddForm) {
      this.newBuilding = {
        id: 0,
        name: '',
        address: '',
        floor: '',
        other: ''
      };
    }
  }

  updateBuilding() {
    if (this.editingBuilding) {
      this.buildingService.updateBuilding(this.editingBuilding).subscribe(
        (building) => {
          // Обновление данных в массиве buildings
          const index = this.buildings.findIndex(b => b.id === building.id);
          if (index > -1) {
            this.buildings[index] = building;
          }
          this.editingBuilding = null;
          this.showAddForm = false; // Скрыть форму после обновления
        },
        (error) => {
          console.error('Ошибка при обновлении корпуса:', error);
        }
      );
    }
  }

  editBuilding(building: BuildingDto) {
    this.editingBuilding = building;
    setTimeout(() => {
      
    }, 0);
  }

  deleteBuilding(id: number) {
    this.buildingService.deleteBuilding(id).subscribe(
      () => {
        // Удаление корпуса из массива buildings
        this.buildings = this.buildings.filter(b => b.id !== id);
      },
      (error) => {
        console.error('Ошибка при удалении корпуса:', error);
      }
    );
  }

  saveBuilding() {
    if (this.editingBuilding) {
      this.updateBuilding();
    } else {
      this.buildingService.addBuilding(this.newBuilding).subscribe(
        (building) => {
          // Обработка успешного добавления
          this.buildings.push(building); // Добавляем новый корпус в список
          this.newBuilding = {
            id: 0,
            name: '',
            address: '',
            floor: '',
            other: ''
          };
          this.showAddForm = false; // Скрыть форму после добавления
          this.getBuildings();
        },
        (error) => {
          // Обработка ошибки
          console.error('Ошибка при добавлении корпуса:', error);
        }
      );
    }
  }

  saveEditedBuilding() { // Новый метод для сохранения изменений
    if (this.editingBuilding) {
      this.buildingService.updateBuilding(this.editingBuilding).subscribe(
        (building) => {
          // Обработка успешного обновления
          const index = this.buildings.findIndex(b => b.id === building.id);
          if (index > -1) {
            this.buildings[index] = building;
          }
          this.editingBuilding = null; // Сбросить editingBuilding
          this.showAddForm = false; // Скрыть форму после обновления
        },
        (error) => {
          // Обработка ошибки
          console.error('Ошибка при обновлении корпуса:', error);
        }
      );
    }
  }
}