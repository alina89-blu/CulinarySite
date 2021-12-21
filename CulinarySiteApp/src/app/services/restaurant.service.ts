import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { IRestaurant } from '../interfaces/restaurant.interface';
import { Restaurant } from '../viewmodels/restaurant.class';

@Injectable()
export class RestaurantService {
  public url: string = '/api/restaurant';

  constructor(private http: HttpClient) {}

  public getRestaurantListWithInclude(): Observable<IRestaurant[]> {
    return this.http.get<IRestaurant[]>(this.url);
  }

  public getRestaurantWithInclude(id: number): Observable<IRestaurant> {
    return this.http.get<IRestaurant>(this.url + '/' + id);
  }

  public createRestaurant(restaurant: Restaurant): Observable<void> {
    return this.http.post<void>(this.url, restaurant);
  }

  public updateRestaurant(restaurant: Restaurant): Observable<void> {
    return this.http.put<void>(this.url, restaurant);
  }

  public deleteRestaurant(id: number): Observable<void> {
    return this.http.delete<void>(this.url + '/' + id);
  }
}
