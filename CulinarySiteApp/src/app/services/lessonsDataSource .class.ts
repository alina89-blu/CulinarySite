import { CollectionViewer, DataSource } from '@angular/cdk/collections';
import { BehaviorSubject, catchError, finalize, Observable, of } from 'rxjs';
import { IBookDetailListModel } from '../interfaces/book/book-detail-list-model.interface';
import { CoursesService } from './courses.service';

export class LessonsDataSource implements DataSource<IBookDetailListModel> {
  private lessonsSubject = new BehaviorSubject<IBookDetailListModel[]>([]);
  private loadingSubject = new BehaviorSubject<boolean>(false);

  public loading$ = this.loadingSubject.asObservable();

  constructor(private coursesService: CoursesService) {}

  connect(
    collectionViewer: CollectionViewer
  ): Observable<IBookDetailListModel[]> {
    return this.lessonsSubject.asObservable();
  }

  disconnect(collectionViewer: CollectionViewer): void {
    this.lessonsSubject.complete();
    this.loadingSubject.complete();
  }

  loadLessons(
    // courseId: number,
    filter = '',
    sortDirection = 'asc',
    pageIndex = 0,
    pageSize = 3
  ) {
    this.loadingSubject.next(true);

    this.coursesService
      .findLessons(filter, sortDirection, pageIndex, pageSize)
      .pipe(
        catchError(() => of([])),
        finalize(() => this.loadingSubject.next(false))
      )
      .subscribe((lessons) => this.lessonsSubject.next(lessons));
  }
}
