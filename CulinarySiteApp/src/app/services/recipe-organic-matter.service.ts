import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { IRecipeOrganicMatterListModel } from '../interfaces/recipe-organic-matter/recipe-organic-matter-list-model.interface';
import { IRecipeOrganicMatterDetailModel } from '../interfaces/recipe-organic-matter/recipe-organic-matter-detail-model.interface';
import { CreateRecipeOrganicMatterModel } from '../viewmodels/recipe-organic-matter/create-recipe-organic-matter-model.class';
import { UpdateRecipeOrganicMatterModel } from '../viewmodels/recipe-organic-matter/update-recipe-organic-matter-model.class';

@Injectable()
export class RecipeOrganicMatterService {
  public url: string = '/api/recipeorganicmatter';

  constructor(private http: HttpClient) {}

  public getRecipeOrganicMatterList(
    withRelated: boolean
  ): Observable<IRecipeOrganicMatterListModel[]> {
    return this.http.get<IRecipeOrganicMatterListModel[]>(
      this.url + '/' + withRelated
    );
  }

  public getRecipeOrganicMatter(
    id: number,
    withRelated: boolean
  ): Observable<IRecipeOrganicMatterDetailModel> {
    return this.http.get<IRecipeOrganicMatterDetailModel>(
      this.url + '/' + id + '/' + withRelated
    );
  }

  public createRecipeOrganicMatter(
    createRecipeOrganicMatterModel: CreateRecipeOrganicMatterModel
  ): Observable<void> {
    return this.http.post<void>(this.url, createRecipeOrganicMatterModel);
  }

  public updateRecipeOrganicMatter(
    updateRecipeOrganicMatterModel: UpdateRecipeOrganicMatterModel
  ): Observable<void> {
    return this.http.put<void>(this.url, updateRecipeOrganicMatterModel);
  }

  public deleteRecipeOrganicMatter(id: number): Observable<void> {
    return this.http.delete<void>(this.url + '/' + id);
  }
}
