import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ITag } from '../interfaces/tag.interface';
import { Tag } from '../viewmodels/tag.class';

@Injectable()
export class TagService {
  public url: string = '/api/tag';

  constructor(private http: HttpClient) {}

  public getTagListWithInclude(): Observable<ITag[]> {
    return this.http.get<ITag[]>(this.url);
  }

  public getTagWithInclude(id: number): Observable<ITag> {
    return this.http.get<ITag>(this.url + '/' + id);
  }

  public createTag(tag: Tag): Observable<void> {
    return this.http.post<void>(this.url, tag);
  }

  public updateTag(tag: Tag): Observable<void> {
    return this.http.put<void>(this.url, tag);
  }

  public deleteTag(id: number): Observable<void> {
    return this.http.delete<void>(this.url + '/' + id);
  }
}
