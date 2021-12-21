import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Book } from '../viewmodels/book.class';
import { Observable } from 'rxjs';
import { IBook } from '../interfaces/book.interface';

@Injectable()
export class BookService {
  public url: string = '/api/book';

  constructor(private http: HttpClient) {}

  public getBookListWithInclude(): Observable<IBook[]> {
    return this.http.get<IBook[]>(this.url);
  }
  public getBookWithInclude(id: number): Observable<IBook> {
    return this.http.get<IBook>(this.url + '/' + id);
  }
  public createBook(book: Book): Observable<void> {
    return this.http.post<void>(this.url, book);
  }
  public updateBook(book: Book): Observable<void> {
    return this.http.put<void>(this.url, book);
  }
  public deleteBook(id: number): Observable<void> {
    return this.http.delete<void>(this.url + '/' + id);
  }
}
