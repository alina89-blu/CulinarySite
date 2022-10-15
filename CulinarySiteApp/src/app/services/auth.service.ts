import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { catchError, Observable, tap } from 'rxjs';
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  public url: string = '/api/identity';

  constructor(private http: HttpClient) {}

  public login(data: any): Observable<any> {
    return this.http.post(this.url + '/' + 'login', data);
  }

  public register(data: any): Observable<any> {
    return this.http.post(this.url + '/' + 'register', data);
  }

  saveToken(token: string) {
    localStorage.setItem('token', token);
  }
  getToken() {
    return localStorage.getItem('token');
  }

  isAuthenticated(): boolean {
    return !!this.getToken();
  }

  logout() {
    return localStorage.removeItem('token');
  }
}
