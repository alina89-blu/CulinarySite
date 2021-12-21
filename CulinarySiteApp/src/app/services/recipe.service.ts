import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { IRecipe } from '../interfaces/recipe.interface';
import { Recipe } from '../viewmodels/recipe.class';

@Injectable()
export class RecipeService {
  public url: string = '/api/recipe';

  constructor(private http: HttpClient) {}

  public getRecipeListWithInclude(): Observable<IRecipe[]> {
    return this.http.get<IRecipe[]>(this.url);
  }

  public getRecipeWithInclude(id: number): Observable<IRecipe> {
    return this.http.get<IRecipe>(this.url + '/' + id);
  }

  public createRecipe(recipe: Recipe): Observable<void> {
    return this.http.post<void>(this.url, recipe);
  }

  public updateRecipe(recipe: Recipe): Observable<void> {
    return this.http.put<void>(this.url, recipe);
  }

  public deleteRecipe(id: number): Observable<void> {
    return this.http.delete<void>(this.url + '/' + id);
  }
}
