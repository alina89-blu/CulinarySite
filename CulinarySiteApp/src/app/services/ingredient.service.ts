import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { IIngredient } from '../interfaces/ingredient.interface';
import { Ingredient } from '../viewmodels/ingredient.class';

@Injectable()
export class IngredientService {
  public url: string = '/api/ingredient';

  constructor(private http: HttpClient) {}

  public getIngredientListWithInclude(): Observable<IIngredient[]> {
    return this.http.get<IIngredient[]>(this.url);
  }

  public getIngredientWithInclude(id: number): Observable<IIngredient> {
    return this.http.get<IIngredient>(this.url + '/' + id);
  }

  public createIngredient(Ingredient: Ingredient): Observable<void> {
    return this.http.post<void>(this.url, Ingredient);
  }

  public updateIngredient(Ingredient: Ingredient): Observable<void> {
    return this.http.put<void>(this.url, Ingredient);
  }

  public deleteIngredient(id: number): Observable<void> {
    return this.http.delete<void>(this.url + '/' + id);
  }
}
