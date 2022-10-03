import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ITelephoneDetailModel } from '../interfaces/telephone/telephone-detail-model.interface';
import { ITelephoneListModel } from '../interfaces/telephone/telephone-list-model.interface';
import { CreateTelephoneModel } from '../viewmodels/telephone/create-telephone-model.class';
import { UpdateTelephoneModel } from '../viewmodels/telephone/update-telephone-model.class';

@Injectable()
export class TelephoneService {
  public url: string = '/api/telephone';

  constructor(private http: HttpClient) {}

  public getTelephoneList(
    withRelated: boolean
  ): Observable<ITelephoneListModel[]> {
    return this.http.get<ITelephoneListModel[]>(this.url + '/' + withRelated);
  }

  public getTelephone(
    id: number,
    withRelated: boolean
  ): Observable<ITelephoneDetailModel> {
    return this.http.get<ITelephoneDetailModel>(
      this.url + '/' + id + '/' + withRelated
    );
  }

  public createTelephone(
    createTelephoneModel: CreateTelephoneModel
  ): Observable<void> {
    return this.http.post<void>(this.url, createTelephoneModel);
  }

  public updateTelephone(
    updateTelephoneModel: UpdateTelephoneModel
  ): Observable<void> {
    return this.http.put<void>(this.url, updateTelephoneModel);
  }

  public delete(id: number): Observable<void> {
    return this.http.delete<void>(this.url + '/' + id);
  }
}
