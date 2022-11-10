import { CollectionViewer, DataSource } from '@angular/cdk/collections';
import { BehaviorSubject, catchError, finalize, Observable, of } from 'rxjs';
import { IBookDetailListModel } from '../interfaces/book/book-detail-list-model.interface';
import { BookService } from './book.service';

export class BooksDataSource implements DataSource<IBookDetailListModel> {
  private booksSubject = new BehaviorSubject<IBookDetailListModel[]>([]);
  private loadingSubject = new BehaviorSubject<boolean>(false);
  public loading$ = this.loadingSubject.asObservable();

  constructor(private bookService: BookService) {}

  public connect(
    collectionViewer: CollectionViewer
  ): Observable<IBookDetailListModel[]> {
    return this.booksSubject.asObservable();
  }

  public disconnect(collectionViewer: CollectionViewer): void {
    this.booksSubject.complete();
    this.loadingSubject.complete();
  }

  public loadBooks(pageIndex = 0, pageSize = 3): void {
    this.loadingSubject.next(true);

    this.bookService
      .getPagedBooks(pageIndex, pageSize)
      .pipe(
        catchError(() => of([])),
        finalize(() => this.loadingSubject.next(false))
      )
      .subscribe((books) => this.booksSubject.next(books));
  }
}
