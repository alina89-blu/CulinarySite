import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { IComment } from '../interfaces/comment.interface';

@Injectable()
export class CommentService {
  public url: string = '/api/comment';

  constructor(private http: HttpClient) {}

  public getCommentListWithInclude(): Observable<IComment[]> {
    return this.http.get<IComment[]>(this.url);
  }

  public getCommentWithInclude(id: number): Observable<IComment> {
    return this.http.get<IComment>(this.url + '/' + id);
  }

  public createComment(comment: Comment): Observable<void> {
    return this.http.post<void>(this.url, comment);
  }

  public deleteComment(id: number): Observable<void> {
    return this.http.delete<void>(this.url + '/' + id);
  }
}
