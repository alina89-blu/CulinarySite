import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { IRecipeIngredientDetailModel } from '../interfaces/recipe-ingredient/recipe-ingredient-detail-model.interface';
import { IRecipeIngredientListModel } from '../interfaces/recipe-ingredient/recipe-ingredient-list-model.interface';
import { CreateRecipeIngredientModel } from '../viewmodels/recipe-ingredient/create-recipe-ingredient-model.class';
import { UpdateRecipeIngredientModel } from '../viewmodels/recipe-ingredient/update-recipe-ingredient-model.class';

@Injectable()
export class RecipeIngredientService {
  public url: string = '/api/recipeingredient';

  constructor(private http: HttpClient) {}

  public getRecipeIngredientList(
    withRelated: boolean
  ): Observable<IRecipeIngredientListModel[]> {
    return this.http.get<IRecipeIngredientListModel[]>(
      this.url + '/' + withRelated
    );
  }

  public getRecipeIngredient(
    id: number,
    withRelated: boolean
  ): Observable<IRecipeIngredientDetailModel> {
    return this.http.get<IRecipeIngredientDetailModel>(
      this.url + '/' + id + '/' + withRelated
    );
  }

  public createRecipeIngredient(
    createRecipeIngredientModel: CreateRecipeIngredientModel
  ): Observable<void> {
    return this.http.post<void>(this.url, createRecipeIngredientModel);
  }

  public updateRecipeIngredient(
    updateRecipeIngredientModel: UpdateRecipeIngredientModel
  ): Observable<void> {
    return this.http.put<void>(this.url, updateRecipeIngredientModel);
  }

  public deleteRecipeIngredient(id: number): Observable<void> {
    return this.http.delete<void>(this.url + '/' + id);
  }
}
