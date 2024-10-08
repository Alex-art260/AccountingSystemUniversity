import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Auditorium } from '../model/auditorium.model';
import { BuildingDto } from '../model/buildingDto.model';
import { TypeRoomDto } from '../model/typeRoomDto.model'  

@Injectable({
  providedIn: 'root'
})
export class AuditoriumService {
  private apiUrl = 'https://localhost:7257/api/Auditory/GetAll';
  private addAuditory = 'https://localhost:7257/api/Auditory/Add'; 
  private deleteAuditory = 'https://localhost:7257/api/Auditory/Delete'; 
  private updateAuditory = 'https://localhost:7257/api/Auditory/Update'; 
    private apiBuildings = 'https://localhost:7257/api/Auditory/GetBuildings'
  private apiRooms = 'https://localhost:7257/api/Auditory/GetTypeRooms'


  constructor(private http: HttpClient) { }

  getAuditoriums(): Observable<Auditorium[]> {
    return this.http.get<Auditorium[]>(this.apiUrl);
  }

  addAuditorium(auditorium: Auditorium): Observable<Auditorium> {
    return this.http.post<Auditorium>(this.addAuditory, auditorium, { headers: { 'Content-Type': 'application/json' }});
  }

  updateAuditorium(auditorium: Auditorium): Observable<Auditorium> {
    return this.http.put<Auditorium>(`${this.updateAuditory}/${auditorium.id}`, auditorium, { headers: { 'Content-Type': 'application/json' } });
  }

  deleteAuditorium(id: number): Observable<void> {
    return this.http.delete<void>(`${this.deleteAuditory}/${id}`);
  }

  getBuildings(): Observable<BuildingDto[]> {
    return this.http.get<BuildingDto[]>(this.apiBuildings);
  }

  getTypeRooms(): Observable<TypeRoomDto[]> {
    return this.http.get<TypeRoomDto[]>(this.apiRooms);
  }
}