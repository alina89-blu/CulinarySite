import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { IPagedList } from '../interfaces/common/paged-list';
import { IRecipeDetailModel } from '../interfaces/recipe/recipe-detail-model.interface';
import { IRecipeListModel } from '../interfaces/recipe/recipe-list-model.interface';
import { IRecipeModel } from '../interfaces/recipe/recipe-model.interface';
import { CreateRecipeModel } from '../viewmodels/recipe/create-recipe-model.class';
import { UpdateRecipeModel } from '../viewmodels/recipe/update-recipe-model.class';

@Injectable()
export class RecipeService {
  public url: string = '/api/recipe';

  constructor(private http: HttpClient) {}

  public getRecipeDetailList(
    withRelated: boolean
  ): Observable<IRecipeListModel[]> {
    return this.http.get<IRecipeListModel[]>(this.url + '/' + withRelated);
  }

  public getRecipeList(): Observable<IRecipeModel[]> {
    return this.http.get<IRecipeModel[]>(this.url);
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

  public getPagedRecipes(
    pageNumber: number,
    pageSize: number,
    isAscending: boolean,
    activeColumn: string,
    filterValue: string
  ): Observable<IPagedList<IRecipeListModel>> {
    let params = new HttpParams();
    params = params.set('pageNumber', pageNumber.toString());
    params = params.set('pageSize', pageSize.toString());

    if (filterValue) {
      params = params.set('filterValue', filterValue);
    }

    if (activeColumn) {
      params = params.set('isAscending', isAscending);
      params = params.set('activeColumn', activeColumn);
    }

    return this.http.get<IPagedList<IRecipeListModel>>(
      this.url + '/' + 'paged',
      {
        params,
      }
    );
  }
}
