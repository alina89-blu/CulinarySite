import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { IDishListModel } from '../interfaces/dish/dish-list-model.interface';
import { IDishDetailModel } from '../interfaces/dish/dish-detail-model.interface';
import { CreateDishModel } from '../viewmodels/dish/create-dish-model.class';
import { UpdateDishModel } from '../viewmodels/dish/update-dish-model.class';
import { IDishModel } from '../interfaces/dish/dish-model.interface';

@Injectable()
export class DishService {
  public url: string = '/api/dish';

  constructor(private http: HttpClient) {}

  public getDishDetailList(withRelated: boolean): Observable<IDishListModel[]> {
    return this.http.get<IDishListModel[]>(this.url + '/' + withRelated);
  }

  public getDishList(): Observable<IDishModel[]> {
    return this.http.get<IDishModel[]>(this.url);
  }

  public getDish(
    id: number,
    withRelated: boolean
  ): Observable<IDishDetailModel> {
    return this.http.get<IDishDetailModel>(
      this.url + '/' + id + '/' + withRelated
    );
  }

  public createDish(createDishModel: CreateDishModel): Observable<void> {
    return this.http.post<void>(this.url, createDishModel);
  }

  public updateDish(updateDishModel: UpdateDishModel): Observable<void> {
    return this.http.put<void>(this.url, updateDishModel);
  }

  public deleteDish(id: number): Observable<void> {
    return this.http.delete<void>(this.url + '/' + id);
  }
}
