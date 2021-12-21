import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ITelephone } from '../interfaces/telephone.interface';
import { Telephone } from '../viewmodels/telephone.class';

@Injectable()
export class TelephoneService {
  public url: string = '/api/telephone';

  constructor(private http: HttpClient) {}

  public getTelephoneList(): Observable<ITelephone[]> {
    return this.http.get<ITelephone[]>(this.url);
  }

  public getTelephone(id: number): Observable<ITelephone> {
    return this.http.get<ITelephone>(this.url + '/' + id);
  }

  public createTelephone(telephone: Telephone): Observable<void> {
    return this.http.post<void>(this.url, telephone);
  }

  public updateTelephone(telephone: Telephone): Observable<void> {
    return this.http.put<void>(this.url, telephone);
  }

  public delete(id: number): Observable<void> {
    return this.http.delete<void>(this.url + '/' + id);
  }
}
