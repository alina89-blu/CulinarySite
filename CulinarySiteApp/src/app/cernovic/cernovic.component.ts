import { AfterViewInit, Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { tap } from 'rxjs';
import { BookService } from '../services/book.service';
import { BooksDataSource } from '../services/booksDataSource.class';

@Component({
  selector: 'app-cernovic',
  templateUrl: './cernovic.component.html',
  styleUrls: ['./cernovic.component.css'],
})
export class CernovicComponent implements AfterViewInit, OnInit {
  public totalRows: number = 0;
  public pageSize: number = 5;
  public currentPage: number = 0;
  public pageSizeOptions: number[] = [3, 5, 10, 25];

  dataSource: BooksDataSource;
  displayedColumns: string[] = ['number', 'name', 'year', 'author', 'action'];

  @ViewChild(MatPaginator) paginator: MatPaginator;

  constructor(private bookService: BookService) {}

  public ngOnInit(): void {
    this.dataSource = new BooksDataSource(this.bookService);
    this.dataSource.loadBooks(0, 3);
  }

  public ngAfterViewInit(): void {
    this.paginator.page.pipe(tap(() => this.loadBooksPage())).subscribe();
  }

  public loadBooksPage(): void {
    this.dataSource.loadBooks(
      this.paginator.pageIndex,
      this.paginator.pageSize
    );
  }

  public deleteBook(id: number) {
    this.bookService.deleteBook(id).subscribe(() => this.loadBooksPage());
  }
}
