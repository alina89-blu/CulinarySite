import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map, Observable } from 'rxjs';
import { IBookDetailListModel } from '../interfaces/book/book-detail-list-model.interface';

@Injectable({
  providedIn: 'root',
})
export class CoursesService {
  constructor(private http: HttpClient) {}

  findLessons(
    // courseId: number,
    filter = '',
    sortOrder = 'asc',
    pageNumber = 0,
    pageSize = 3
  ): Observable<IBookDetailListModel[]> {
    return this.http.get<IBookDetailListModel[]>('/api/book/paged', {
      params: new HttpParams()
        // .set('courseId', courseId.toString())
        .set('filter', filter)
        .set('sortOrder', sortOrder)
        .set('pageNumber', pageNumber.toString())
        .set('pageSize', pageSize.toString()),
    });
    // .pipe(map((res) => res['payload']));
  }
}
