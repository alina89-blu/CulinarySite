import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ISubscriber } from '../interfaces/subscriber.interface';
import { Subscriber } from '../viewmodels/subscriber.class';

@Injectable()
export class SubscriberService {
  public url: string = '/api/subscriber';

  constructor(private http: HttpClient) {}

  public getSubscriberList(): Observable<ISubscriber[]> {
    return this.http.get<ISubscriber[]>(this.url);
  }

  public getSubscriber(id: number): Observable<ISubscriber> {
    return this.http.get<ISubscriber>(this.url + '/' + id);
  }

  public createSubscriber(subscriber: Subscriber): Observable<void> {
    return this.http.post<void>(this.url, subscriber);
  }

  public updateSubscriber(subscriber: Subscriber): Observable<void> {
    return this.http.put<void>(this.url, subscriber);
  }

  public delete(id: number): Observable<void> {
    return this.http.delete<void>(this.url + '/' + id);
  }
}
