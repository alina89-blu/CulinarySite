import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import jwtDecode from 'jwt-decode';
import { Observable } from 'rxjs';

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

  public saveToken(token: string): void {
    localStorage.setItem('token', token);
  }

  public getToken(): string | null {
    return localStorage.getItem('token');
  }

  public isAuthenticated(): boolean {
    return !!this.getToken();
  }

  public logout(): void {
    return localStorage.removeItem('token');
  }

  public isAdmin(): boolean {
    const token = this.getToken();

    if (!token) {
      return false;
    }

    const decodedUser = jwtDecode<{ role: string }>(token);

    return decodedUser.role.includes('admin');
  }
}
