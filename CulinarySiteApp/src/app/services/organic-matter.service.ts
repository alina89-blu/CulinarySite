import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { IOrganicMatterDetailModel } from '../interfaces/organic-matter/organic-matter-detail-model.interface';
import { IOrganicMatterListModel } from '../interfaces/organic-matter/organic-matter-list-model.interface';
import { CreateOrganicMatterModel } from '../viewmodels/organic-matter/create-organic-matter-model.class';
import { UpdateOrganicMatterModel } from '../viewmodels/organic-matter/update-organic-matter-model.class';

@Injectable()
export class OrganicMatterService {
  public url: string = '/api/organicmatter';

  constructor(private http: HttpClient) {}

  public getOrganicMatterList(): Observable<IOrganicMatterListModel[]> {
    return this.http.get<IOrganicMatterListModel[]>(this.url);
  }

  public getOrganicMatter(id: number): Observable<IOrganicMatterDetailModel> {
    return this.http.get<IOrganicMatterDetailModel>(this.url + '/' + id);
  }

  public createOrganicMatter(
    createOrganicMatterModel: CreateOrganicMatterModel
  ): Observable<void> {
    return this.http.post<void>(this.url, createOrganicMatterModel);
  }

  public updateOrganicMatter(
    updateOrganicMatterModel: UpdateOrganicMatterModel
  ): Observable<void> {
    return this.http.put<void>(this.url, updateOrganicMatterModel);
  }

  public delete(id: number): Observable<void> {
    return this.http.delete<void>(this.url + '/' + id);
  }
}
