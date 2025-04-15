import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../environments/environment';
import { Building } from '../models/building-model';

@Injectable({ providedIn: 'root' })
export class BuildingService {
  private apiUrl = `${environment.apiUrl}/api/buildings`;
  private tokenKey = 'token';

  constructor(private http: HttpClient) {}

  private getAuthHeaders() {
    const token = localStorage.getItem('token');
    return {
      headers: new HttpHeaders({
        Authorization: `Bearer ${token}`
      })
    };
  }

  // Fetch all buildings
  getBuildings(): Observable<Building[]> {
    return this.http.get<Building[]>(this.apiUrl, this.getAuthHeaders());
  }

  // Create a new building
  createBuilding(building: Building): Observable<Building> {
    return this.http.post<Building>(this.apiUrl, building, this.getAuthHeaders());
  }

  // Update an existing building
  updateBuilding(building: Building): Observable<void> {
    return this.http.put<void>(`${this.apiUrl}/${building.id}`, building, this.getAuthHeaders());
  }

  // Delete a building
  deleteBuilding(buildingId: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${buildingId}`, this.getAuthHeaders());
  }

  // Fetch a specific building by ID
  getBuildingById(buildingId: number): Observable<Building> {
    return this.http.get<Building>(`${this.apiUrl}/${buildingId}`, this.getAuthHeaders());
  }
  

  // Get the stored token
  getToken(): string | null {
    return localStorage.getItem(this.tokenKey);
  }
}
