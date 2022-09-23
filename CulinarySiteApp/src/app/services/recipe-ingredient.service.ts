import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { IIngredientDetailModel } from '../interfaces/ingredient/ingredient-detail-model.interface';
import { IIngredientListModel } from '../interfaces/ingredient/ingredient-list-model.interface';
import { CreateIngredientModel } from '../viewmodels/ingredient/create-ingredient-model.class';
import { UpdateIngredientModel } from '../viewmodels/ingredient/update-ingredient-model.class';

@Injectable()
export class RecipeIngredientService {
  public url: string = '/api/recipeingredient';

  constructor(private http: HttpClient) {}

  public getRecipeIngredientList(
    withRelated: boolean
  ): Observable<IIngredientListModel[]> {
    return this.http.get<IIngredientListModel[]>(this.url + '/' + withRelated);
  }

  public getRecipeIngredient(
    id: number,
    withRelated: boolean
  ): Observable<IIngredientDetailModel> {
    return this.http.get<IIngredientDetailModel>(
      this.url + '/' + id + '/' + withRelated
    );
  }

  public createRecipeIngredient(
    createRecipeIngredientModel: CreateIngredientModel
  ): Observable<void> {
    return this.http.post<void>(this.url, createRecipeIngredientModel);
  }

  public updateRecipeIngredient(
    updateRecipeIngredientModel: UpdateIngredientModel
  ): Observable<void> {
    return this.http.put<void>(this.url, updateRecipeIngredientModel);
  }

  public deleteRecipeIngredient(id: number): Observable<void> {
    return this.http.delete<void>(this.url + '/' + id);
  }
}
