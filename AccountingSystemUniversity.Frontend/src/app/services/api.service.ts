import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { BuildingDto } from '../model/buildingDto.model';
import { TypeRoomDto } from '../model/typeRoomDto.model'  

@Injectable({
  providedIn: 'root'
})
export class ApiService {
  private apiBuildings = 'https://localhost:7257/api/Auditory/GetBuildings'
  private apiRooms = 'https://localhost:7257/api/Auditory/GetTypeRooms'

  constructor(private http: HttpClient) { }

  getBuildings(): Observable<BuildingDto[]> {
    return this.http.get<BuildingDto[]>(this.apiBuildings, { headers: { 'Content-Type': 'application/json' }});
  }

  getTypeRooms(): Observable<TypeRoomDto[]> {
    return this.http.get<TypeRoomDto[]>(this.apiRooms, { headers: { 'Content-Type': 'application/json' }});
  }
}