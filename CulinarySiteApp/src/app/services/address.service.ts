import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { CreateAddressModel } from '../viewmodels/address/create-address-model.class';
import { UpdateAddressModel } from '../viewmodels/address/update-address-model.class';
import { IAddressListModel } from '../interfaces/address/address-list-model.interface';
import { IAddressDetailModel } from '../interfaces/address/address-detail-model.interface';
import { AuthService } from './auth.service';

@Injectable()
export class AddressService {
  public url: string = '/api/address';

  constructor(private http: HttpClient) {}

  public getAddressList(): Observable<IAddressListModel[]> {
    return this.http.get<IAddressListModel[]>(this.url);
  }

  public getAddress(id: number): Observable<IAddressDetailModel> {
    return this.http.get<IAddressDetailModel>(this.url + '/' + id);
  }

  public createAddress(
    createAddressModel: CreateAddressModel
  ): Observable<void> {
    return this.http.post<void>(this.url, createAddressModel);
  }

  public updateAddress(
    updateAddressModel: UpdateAddressModel
  ): Observable<void> {
    return this.http.put<void>(this.url, updateAddressModel);
  }

  public delete(id: number): Observable<void> {
    return this.http.delete<void>(this.url + '/' + id);
  }
}
