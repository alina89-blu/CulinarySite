import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { map, Observable } from 'rxjs';
import { IBookDetailListModel } from '../interfaces/book/book-detail-list-model.interface';
import { IBookDetailModel } from '../interfaces/book/book-detail-model.interface';
import { CreateBookModel } from '../viewmodels/book/create-book-model.class';
import { UpdateBookModel } from '../viewmodels/book/update-book-model.class';
import { IBookModel } from '../interfaces/book/book-model.interface';

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

  public getSortedBooksByName(
    withRelated: boolean
  ): Observable<IBookDetailListModel[]> {
    return this.http.get<IBookDetailListModel[]>(
      this.url + '/' + withRelated + '/' + 'sortedByName'
    );
  }

  public getSortedBooksByYear(
    withRelated: boolean
  ): Observable<IBookDetailListModel[]> {
    return this.http.get<IBookDetailListModel[]>(
      this.url + '/' + withRelated + '/' + 'sortedByYear'
    );
  }

  /* public getBook1(id: number): Observable<IBookDetailModel> {
    let params = new HttpParams();
    if (id) {
      params = params.set('getBook', id);
    }

    return this.http.get<IBookDetailModel>(this.url, { params });
  }*/

  public getPagedBooks(
    pageNumber = 0,
    pageSize = 3
  ): Observable<IBookDetailListModel[]> {
    let params = new HttpParams();
    params = params.set('pageNumber', pageNumber.toString());
    params = params.set('pageSize', pageSize.toString());

    return this.http.get<IBookDetailListModel[]>(this.url + '/' + 'paged', {
      params,
    });
  }
}
