import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ICommentListModel } from '../interfaces/comment/comment-list-model.interface';
import { ICommentDetailModel } from '../interfaces/comment/comment-detail-model.interface';
import { CreateCommentModel } from '../viewmodels/comment/create-comment-model.class';
import { UpdateCommentModel } from '../viewmodels/comment/update-comment-model.class';

@Injectable()
export class CommentService {
  public url: string = '/api/comment';

  constructor(private http: HttpClient) {}

  public getCommentList(withRelated: boolean): Observable<ICommentListModel[]> {
    return this.http.get<ICommentListModel[]>(this.url + '/' + withRelated);
  }

  public getComment(
    id: number,
    withRelated: boolean
  ): Observable<ICommentDetailModel> {
    return this.http.get<ICommentDetailModel>(
      this.url + '/' + id + '/' + withRelated
    );
  }

  public createComment(
    createCommentModel: CreateCommentModel
  ): Observable<void> {
    return this.http.post<void>(this.url, createCommentModel);
  }

  public updateComment(
    updateCommentModel: UpdateCommentModel
  ): Observable<void> {
    return this.http.post<void>(this.url, updateCommentModel);
  }

  public deleteComment(id: number): Observable<void> {
    return this.http.delete<void>(this.url + '/' + id);
  }
}
