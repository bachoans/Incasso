// src/app/services/auth.service.ts

import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, BehaviorSubject } from 'rxjs';
import { tap } from 'rxjs/operators';
import { environment } from '../../../environments/environment';

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  private authUrl = `${environment.apiUrl}/api/auth` // Replace with your API URL
  private tokenKey = 'token';

  // Observable to track authentication status
  private loggedIn = new BehaviorSubject<boolean>(this.hasToken());

  constructor(private http: HttpClient) {}

  // Check if the token exists in localStorage
  private hasToken(): boolean {
    return !!localStorage.getItem(this.tokenKey);
  }

  // Login method
  login(email: string, password: string): Observable<any> {
    return this.http
      .post<any>(`${this.authUrl}/login`, { email, password })
      .pipe(
        tap((response) => {
          localStorage.setItem(this.tokenKey, response.token);
          this.loggedIn.next(true);
        })
      );
  }

  register(payload: any): Observable<any> {
    return this.http.post<any>(`${this.authUrl}/register`, payload);
  }

  // Logout method
  logout(): void {
    localStorage.removeItem(this.tokenKey);
    this.loggedIn.next(false);
  }

  // Get authentication status
  isLoggedIn(): Observable<boolean> {
    return this.loggedIn.asObservable();
  }

  // Get the stored token
  getToken(): string | null {
    return localStorage.getItem(this.tokenKey);
  }

  getUser(): Observable<any> {
    const token = this.getToken();
    if (!token) {
      return new Observable((observer) => {
        observer.error('No token found');
      });
    }
  
    return this.http.get<any>(`${this.authUrl}/user`, {
      headers: {
        Authorization: `Bearer ${token}`,
      },
    });
  }  
}
