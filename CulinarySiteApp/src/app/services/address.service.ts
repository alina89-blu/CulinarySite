import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Address } from '../viewmodels/address.class';
import { IAddress } from '../interfaces/address.interface';

@Injectable()
export class AddressService {
  public url: string = '/api/address';

  constructor(private http: HttpClient) {}

  public getAddressList(): Observable<IAddress[]> {
    return this.http.get<IAddress[]>(this.url);
  }

  public getAddress(id: number): Observable<IAddress> {
    return this.http.get<IAddress>(this.url + '/' + id);
  }

  public createAddress(address: Address): Observable<void> {
    return this.http.post<void>(this.url, address);
  }

  public updateAddress(address: Address): Observable<void> {
    return this.http.put<void>(this.url, address);
  }

  public delete(id: number): Observable<void> {
    return this.http.delete<void>(this.url + '/' + id);
  }
}
