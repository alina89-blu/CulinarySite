import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ISubscriberDetailModel } from '../interfaces/subscriber/subscriber-detail-model.interface';
import { ISubscriberListModel } from '../interfaces/subscriber/subscriber-list-model.interface';
import { CreateSubscriberModel } from '../viewmodels/subscriber/create-subscriber-model.class';
import { UpdateSubscriberModel } from '../viewmodels/subscriber/update-subscriber-model.class';

@Injectable()
export class SubscriberService {
  public url: string = '/api/subscriber';

  constructor(private http: HttpClient) {}

  public getSubscriberList(
    withRelated: boolean
  ): Observable<ISubscriberListModel[]> {
    return this.http.get<ISubscriberListModel[]>(this.url + '/' + withRelated);
  }

  public getSubscriber(
    id: number,
    withRelated: boolean
  ): Observable<ISubscriberDetailModel> {
    return this.http.get<ISubscriberDetailModel>(
      this.url + '/' + id + '/' + withRelated
    );
  }

  public createSubscriber(
    createSubscriberModel: CreateSubscriberModel
  ): Observable<void> {
    return this.http.post<void>(this.url, createSubscriberModel);
  }

  public updateSubscriber(
    updateSubscriberModel: UpdateSubscriberModel
  ): Observable<void> {
    return this.http.put<void>(this.url, updateSubscriberModel);
  }

  public deleteSubscriber(id: number): Observable<void> {
    return this.http.delete<void>(this.url + '/' + id);
  }
}
