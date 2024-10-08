import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { BuildingDto } from '../model/building.model';

@Injectable({
  providedIn: 'root'
})
export class BuildingService {
  private readonly createBuilding =  "https://localhost:7008/api/Building/Add";
  private readonly getBuildingsURL = "https://localhost:7008/api/Building/GetBuildings";
  private readonly deleteBuildingURL = "https://localhost:7008/api/Building/Delete";
  private readonly updateBuildingURL = "https://localhost:7008/api/Building/Update";

  constructor(private http: HttpClient) { }

  getBuildings(): Observable<BuildingDto[]> {
    return this.http.get<BuildingDto[]>(this.getBuildingsURL);
  }

  addBuilding(building:BuildingDto ): Observable<BuildingDto> {
    return this.http.post<BuildingDto>(this.createBuilding, building ,{ headers: { 'Content-Type': 'application/json' } });
  }

  updateBuilding(building: BuildingDto): Observable<BuildingDto> {
    const url = `${this.updateBuildingURL}/${building.id}`;
    return this.http.put<BuildingDto>(url, building, { headers: { 'Content-Type': 'application/json' } });
  }

  deleteBuilding(id: number): Observable<void> {
    const url = `${this.deleteBuildingURL}/${id}`;
    return this.http.delete<void>(url);
  }
}