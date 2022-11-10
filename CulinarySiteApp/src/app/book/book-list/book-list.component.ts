import { AfterViewInit, Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { tap } from 'rxjs';
import { IBookDetailListModel } from 'src/app/interfaces/book/book-detail-list-model.interface';
import { BookService } from 'src/app/services/book.service';
import { BookDetailListModel } from 'src/app/viewmodels/book/book-detail-list-model.class';

@Component({
  selector: 'app-book-list',
  templateUrl: './book-list.component.html',
  styleUrls: ['./book-list.component.css'],
})
export class BookListComponent implements AfterViewInit, OnInit {
  constructor(private bookService: BookService) {}

  displayedColumns: string[] = ['code', 'name', 'year', 'author', 'action']; //
  dataSource: MatTableDataSource<IBookDetailListModel>;

  public books: BookDetailListModel[] = [];

  //@ViewChild(MatPaginator) paginator!: MatPaginator;
  @ViewChild(MatPaginator) paginator: MatPaginator; //

  @ViewChild(MatSort) sort!: MatSort;

  public ngOnInit(): void {
    //  this.getBookDetailList();
    this.getPagedBooks(this.currentPage, this.pageSize);
  }

  public deleteBook(id: number) {
    // this.bookService.deleteBook(id).subscribe(() => this.getBookDetailList());
    this.bookService
      .deleteBook(id)
      .subscribe(() => this.getPagedBooks(this.currentPage, this.pageSize));
  }

  /* public getBookDetailList(): void {
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
  }*/

  FilterChange(event: Event) {
    const filvalue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filvalue;
  }
  // Misha
  // public totalRows = 0;
  public totalRows: number = 0;
  public pageSize: number = 5;
  public currentPage: number = 0;
  public pageSizeOptions: number[] = [3, 5, 10, 25];

  public pageChanged(event: PageEvent) {
    console.log({ event });
    this.pageSize = event.pageSize;
    this.currentPage = event.pageIndex;
  }
  //

  public getPagedBooks(currentPage: number, pageSize: number): void {
    this.bookService
      .getPagedBooks(currentPage, pageSize)
      .subscribe((data: IBookDetailListModel[]) => {
        this.books = data.map((x) => new BookDetailListModel(x));
        this.dataSource = new MatTableDataSource<IBookDetailListModel>(
          this.books
        );
      });
  }

  public ngAfterViewInit() {
    this.paginator.page.pipe(tap(() => this.loadPagedBooks())).subscribe();
  }

  public loadPagedBooks(): void {
    this.getPagedBooks(this.currentPage, this.pageSize);
  }
}
