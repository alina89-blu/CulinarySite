import { AfterViewInit, Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { ActivatedRoute } from '@angular/router';
import { tap } from 'rxjs';
import { IBookDetailListModel } from '../interfaces/book/book-detail-list-model.interface';
import { BookService } from '../services/book.service';
import { CoursesService } from '../services/courses.service';
import { LessonsDataSource } from '../services/lessonsDataSource .class';
import { BookDetailListModel } from '../viewmodels/book/book-detail-list-model.class';

@Component({
  selector: 'app-cernovic',
  templateUrl: './cernovic.component.html',
  styleUrls: ['./cernovic.component.css'],
})
export class CernovicComponent implements AfterViewInit, OnInit {
  /* constructor(private bookService: BookService) {}

  displayedColumns: string[] = [
    'code',
    'name',
    'year',
    'author',
    'action',
    
  ];
  dataSource: MatTableDataSource<IBookDetailListModel>;
  public books: BookDetailListModel[];

  @ViewChild(MatPaginator) paginator!: MatPaginator;
  @ViewChild(MatSort) sort!: MatSort;

  public ngOnInit(): void {
    this.getBookDetailList();
  }

  public deleteBook(id: number) {
    this.bookService.deleteBook(id).subscribe(() => this.getBookDetailList());
  }

  public getBookDetailList(): void {
    this.bookService
      .getBookDetailList(true)
      .subscribe((data: IBookDetailListModel[]) => {
        this.books = data.map((x) => new BookDetailListModel(x));
        this.dataSource = new MatTableDataSource<IBookDetailListModel>(
          this.books
        );
        this.dataSource.paginator = this.paginator;
        this.dataSource.sort = this.sort;
      });
  }

  FilterChange(event: Event) {
    const filvalue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filvalue;
  }
  // Misha
  public totalRows = 0;
  public pageSize = 5;
  public currentPage = 0;
  public pageSizeOptions: number[] = [5, 10, 25, 100];

  public pageChanged(event: PageEvent) {
    console.log({ event });
    this.pageSize = event.pageSize;
    this.currentPage = event.pageIndex;
    
  }*/

  /* dataSource: LessonsDataSource;
  displayedColumns = ['code', 'name', 'year', 'author', 'action'];

  constructor(private coursesService: CoursesService) {}

  ngOnInit() {
    this.dataSource = new LessonsDataSource(this.coursesService);
    this.dataSource.loadLessons(1);
  }

  public totalRows = 0;
  public pageSize = 5;
  public currentPage = 0;
  public pageSizeOptions: number[] = [3, 5, 10, 25];*/
  public totalRows = 0;
  public pageSize = 5;
  public currentPage = 0;
  public pageSizeOptions: number[] = [3, 5, 10, 25];

  //course: BookDetailListModel = new BookDetailListModel();
  dataSource: LessonsDataSource;
  displayedColumns = ['code', 'name', 'year', 'author'];

  @ViewChild(MatPaginator) paginator: MatPaginator;

  constructor(
    private coursesService: CoursesService,
    private route: ActivatedRoute
  ) {}

  ngOnInit() {
    // this.course = this.route.snapshot.data['course'];
    this.dataSource = new LessonsDataSource(this.coursesService);
    //this.dataSource.loadLessons(this.course.bookId, '', 'asc', 0, 3);
    this.dataSource.loadLessons('', 'asc', 0, 3);
  }

  ngAfterViewInit() {
    this.paginator.page.pipe(tap(() => this.loadLessonsPage())).subscribe();
  }

  loadLessonsPage() {
    this.dataSource.loadLessons(
      '',
      'asc',
      this.paginator.pageIndex,
      this.paginator.pageSize
    );
  }
}
