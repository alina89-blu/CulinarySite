import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { IAuthor } from '../interfaces/author.interface';
import { Author } from '../viewmodels/author.class';

@Injectable({
  providedIn: 'root',
})
export class AuthorService {
  public url: string = '/api/author';

  constructor(private http: HttpClient) {}

  public getAuthorListWithInclude(): Observable<IAuthor[]> {
    return this.http.get<IAuthor[]>(this.url);
  }

  public getAuthorWithInclude(id: number): Observable<IAuthor> {
    return this.http.get<IAuthor>(this.url + '/' + id);
  }

  public createAuthor(author: Author): Observable<void> {
    return this.http.post<void>(this.url, author);
  }

  public updateAuthor(author: Author): Observable<void> {
    return this.http.put<void>(this.url, author);
  }

  public deleteAuthor(id: number): Observable<void> {
    return this.http.delete<void>(this.url + '/' + id);
  }
}
