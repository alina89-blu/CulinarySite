import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { IOrganicMatterListModel } from '../interfaces/organic-matter/organic-matter-list-model.interface';
import { IOrganicMatterDetailModel } from '../interfaces/organic-matter/organic-matter-detail-model.interface';
import { CreateOrganicMatterModel } from '../viewmodels/organic-matter/create-organic-matter-model.class';
import { UpdateOrganicMatterModel } from '../viewmodels/organic-matter/update-organic-matter-model.class';

@Injectable()
export class RecipeOrganicMatterService {
  public url: string = '/api/recipeorganicmatter';

  constructor(private http: HttpClient) {}

  public getRecipeOrganicMatterList(
    withRelated: boolean
  ): Observable<IOrganicMatterListModel[]> {
    return this.http.get<IOrganicMatterListModel[]>(
      this.url + '/' + withRelated
    );
  }

  public getRecipeOrganicMatter(
    id: number,
    withRelated: boolean
  ): Observable<IOrganicMatterDetailModel> {
    return this.http.get<IOrganicMatterDetailModel>(
      this.url + '/' + id + '/' + withRelated
    );
  }

  public createRecipeOrganicMatter(
    createRecipeOrganicMatterModel: CreateOrganicMatterModel
  ): Observable<void> {
    return this.http.post<void>(this.url, createRecipeOrganicMatterModel);
  }

  public updateRecipeOrganicMatter(
    updateRecipeOrganicMatterModel: UpdateOrganicMatterModel
  ): Observable<void> {
    return this.http.put<void>(this.url, updateRecipeOrganicMatterModel);
  }

  public deleteRecipeOrganicMatter(id: number): Observable<void> {
    return this.http.delete<void>(this.url + '/' + id);
  }
}
