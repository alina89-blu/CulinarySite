import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { IRestaurantDetailModel } from '../interfaces/restaurant/restaurant-detail-model.interface';
import { IRestaurantListModel } from '../interfaces/restaurant/restaurant-list-model.interface';
import { CreateRestaurantModel } from '../viewmodels/restaurant/create-restaurant-model.class';
import { UpdateRestaurantModel } from '../viewmodels/restaurant/update-restaurant-model.class';

@Injectable()
export class RestaurantService {
  public url: string = '/api/restaurant';

  constructor(private http: HttpClient) {}

  public getRestaurantList(
    withRelated: boolean
  ): Observable<IRestaurantListModel[]> {
    return this.http.get<IRestaurantListModel[]>(this.url + '/' + withRelated);
  }

  public getRestaurant(
    id: number,
    withRelated: boolean
  ): Observable<IRestaurantDetailModel> {
    return this.http.get<IRestaurantDetailModel>(
      this.url + '/' + id + '/' + withRelated
    );
  }

  public createRestaurant(
    createRestaurantModel: CreateRestaurantModel
  ): Observable<void> {
    return this.http.post<void>(this.url, createRestaurantModel);
  }

  public updateRestaurant(
    updateRestaurantModel: UpdateRestaurantModel
  ): Observable<void> {
    return this.http.put<void>(this.url, updateRestaurantModel);
  }

  public deleteRestaurant(id: number): Observable<void> {
    return this.http.delete<void>(this.url + '/' + id);
  }
}
