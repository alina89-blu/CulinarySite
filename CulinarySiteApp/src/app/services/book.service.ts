import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { IBookDetailListModel } from '../interfaces/book/book-detail-list-model.interface';
import { IBookDetailModel } from '../interfaces/book/book-detail-model.interface';
import { CreateBookModel } from '../viewmodels/book/create-book-model.class';
import { UpdateBookModel } from '../viewmodels/book/update-book-model.class';
import { IBookModel } from '../interfaces/book/book-model.interface';
import { IPagedList } from '../interfaces/common/paged-list';

@Injectable()
export class BookService {
  public url: string = '/api/book';

  constructor(private http: HttpClient) {}

  public getBookDetailList(
    withRelated: boolean
  ): Observable<IBookDetailListModel[]> {
    return this.http.get<IBookDetailListModel[]>(this.url + '/' + withRelated);
  }

  public getBookList(): Observable<IBookModel[]> {
    return this.http.get<IBookModel[]>(this.url);
  }

  public getBook(
    id: number,
    withRelated: boolean
  ): Observable<IBookDetailModel> {
    return this.http.get<IBookDetailModel>(
      this.url + '/' + id + '/' + withRelated
    );
  }

  public createBook(createBookModel: CreateBookModel): Observable<void> {
    return this.http.post<void>(this.url, createBookModel);
  }

  public updateBook(updateBookModel: UpdateBookModel): Observable<void> {
    return this.http.put<void>(this.url, updateBookModel);
  }

  public deleteBook(id: number): Observable<void> {
    return this.http.delete<void>(this.url + '/' + id);
  }

  public getPagedBooks(
    pageNumber: number,
    pageSize: number,
    isAscending: boolean,
    activeColumn: string,
    filterValue: string
  ): Observable<IPagedList<IBookDetailListModel>> {
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

    return this.http.get<IPagedList<IBookDetailListModel>>(
      this.url + '/' + 'paged',
      {
        params,
      }
    );
  }
}
