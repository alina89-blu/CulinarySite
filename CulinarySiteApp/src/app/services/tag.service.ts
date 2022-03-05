import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ITagDetailModel } from '../interfaces/tag/tag-detail-model.interface';
import { ITagListModel } from '../interfaces/tag/tag-list-model.interface';
import { CreateTagModel } from '../viewmodels/tag/create-tag-model.class';
import { UpdateTagModel } from '../viewmodels/tag/update-tag-model.class';

@Injectable()
export class TagService {
  public url: string = '/api/tag';

  constructor(private http: HttpClient) {}

  public getTagList(withRelated: boolean): Observable<ITagListModel[]> {
    return this.http.get<ITagListModel[]>(this.url + '/' + withRelated);
  }

  public getTag(id: number, withRelated: boolean): Observable<ITagDetailModel> {
    return this.http.get<ITagDetailModel>(
      this.url + '/' + id + '/' + withRelated
    );
  }

  public createTag(createTagModel: CreateTagModel): Observable<void> {
    return this.http.post<void>(this.url, createTagModel);
  }

  public updateTag(updateTagModel: UpdateTagModel): Observable<void> {
    return this.http.put<void>(this.url, updateTagModel);
  }

  public deleteTag(id: number): Observable<void> {
    return this.http.delete<void>(this.url + '/' + id);
  }
}
