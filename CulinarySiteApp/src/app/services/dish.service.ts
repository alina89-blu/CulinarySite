import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Dish } from '../viewmodels/dish.class';
import { Observable } from 'rxjs';
import { IDish } from '../interfaces/dish.interface';

@Injectable()
export class DishService {
  public url: string = '/api/dish';

  constructor(private http: HttpClient) {}

  public getDishListWithInclude(): Observable<IDish[]> {
    return this.http.get<IDish[]>(this.url);
  }

  public getDishWithInclude(id: number): Observable<IDish> {
    return this.http.get<IDish>(this.url + '/' + id);
  }

  public createDish(dish: Dish): Observable<void> {
    return this.http.post<void>(this.url, dish);
  }

  public updateDish(dish: Dish): Observable<void> {
    return this.http.put<void>(this.url, dish);
  }

  public deleteDish(id: number): Observable<void> {
    return this.http.delete<void>(this.url + '/' + id);
  }
}
