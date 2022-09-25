import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { IIngredientDetailModel } from '../interfaces/ingredient/ingredient-detail-model.interface';
import { IIngredientListModel } from '../interfaces/ingredient/ingredient-list-model.interface';
import { CreateIngredientModel } from '../viewmodels/ingredient/create-ingredient-model.class';
import { UpdateIngredientModel } from '../viewmodels/ingredient/update-ingredient-model.class';

@Injectable()
export class IngredientService {
  public url: string = '/api/ingredient';

  constructor(private http: HttpClient) {}

  public getIngredientList(): Observable<IIngredientListModel[]> {
    return this.http.get<IIngredientListModel[]>(this.url);
  }

  public getIngredient(id: number): Observable<IIngredientDetailModel> {
    return this.http.get<IIngredientDetailModel>(this.url + '/' + id);
  }

  public createIngredient(
    createIngredientModel: CreateIngredientModel
  ): Observable<void> {
    return this.http.post<void>(this.url, createIngredientModel);
  }

  public updateIngredient(
    updateIngredientModel: UpdateIngredientModel
  ): Observable<void> {
    return this.http.put<void>(this.url, updateIngredientModel);
  }

  public deleteIngredient(id: number): Observable<void> {
    return this.http.delete<void>(this.url + '/' + id);
  }
}
