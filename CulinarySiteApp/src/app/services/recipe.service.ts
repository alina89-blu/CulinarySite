import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { IRecipeDetailModel } from '../interfaces/recipe/recipe-detail-model.interface';
import { IRecipeListModel } from '../interfaces/recipe/recipe-list-model.interface';
import { CreateRecipeModel } from '../viewmodels/recipe/create-recipe-model.class';
import { UpdateRecipeModel } from '../viewmodels/recipe/update-recipe-model.class';

@Injectable()
export class RecipeService {
  public url: string = '/api/recipe';

  constructor(private http: HttpClient) {}

  public getRecipeList(withRelated: boolean): Observable<IRecipeListModel[]> {
    return this.http.get<IRecipeListModel[]>(this.url + '/' + withRelated);
  }

  public getRecipe(
    id: number,
    withRelated: boolean
  ): Observable<IRecipeDetailModel> {
    return this.http.get<IRecipeDetailModel>(
      this.url + '/' + id + '/' + withRelated
    );
  }

  public createRecipe(createRecipeModel: CreateRecipeModel): Observable<void> {
    return this.http.post<void>(this.url, createRecipeModel);
  }

  public updateRecipe(updateRecipeModel: UpdateRecipeModel): Observable<void> {
    return this.http.put<void>(this.url, updateRecipeModel);
  }

  public deleteRecipe(id: number): Observable<void> {
    return this.http.delete<void>(this.url + '/' + id);
  }
}
