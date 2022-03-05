import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { IAuthorListModel } from '../interfaces/author/author-list-model.interface';
import { IAuthorDetailModel } from '../interfaces/author/author-detail-model.interface';
import { CreateAuthorModel } from '../viewmodels/author/create-author-model.class';
import { UpdateAuthorModel } from '../viewmodels/author/update-author-model.class';
import { IAuthorModel } from '../interfaces/author/author-model.interface';

@Injectable()
export class AuthorService {
  public url: string = '/api/author';

  constructor(private http: HttpClient) {}

  public getAuthorDetailList(
    withRelated: boolean
  ): Observable<IAuthorListModel[]> {
    return this.http.get<IAuthorListModel[]>(this.url + '/' + withRelated);
  }

  public getAuthorList(): Observable<IAuthorModel[]> {
    return this.http.get<IAuthorModel[]>(this.url);
  }

  public getAuthor(
    id: number,
    withRelated: boolean
  ): Observable<IAuthorDetailModel> {
    return this.http.get<IAuthorDetailModel>(
      this.url + '/' + id + '/' + withRelated
    );
  }

  public createAuthor(createAuthorModel: CreateAuthorModel): Observable<void> {
    return this.http.post<void>(this.url, createAuthorModel);
  }

  public updateAuthor(updateAuthorModel: UpdateAuthorModel): Observable<void> {
    return this.http.put<void>(this.url, updateAuthorModel);
  }

  public deleteAuthor(id: number): Observable<void> {
    return this.http.delete<void>(this.url + '/' + id);
  }
}
