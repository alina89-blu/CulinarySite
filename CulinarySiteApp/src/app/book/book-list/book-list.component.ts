import { Component, OnInit } from '@angular/core';
import { PageEvent } from '@angular/material/paginator';
import { Sort } from '@angular/material/sort';
import { IBookDetailListModel } from 'src/app/interfaces/book/book-detail-list-model.interface';
import { BookService } from 'src/app/services/book.service';

@Component({
  selector: 'app-book-list',
  templateUrl: './book-list.component.html',
  styleUrls: ['./book-list.component.css'],
})
export class BookListComponent implements OnInit {
  public totalRows: number = 0;
  public pageSize: number = 5;
  public activeColumn: string;
  public filterValue: string;
  public isAscending: boolean = true;
  public currentPage: number = 1;
  public pageSizeOptions: number[] = [3, 5, 10, 25];
  public dataSource: IBookDetailListModel[];
  public displayedColumns: string[] = [
    'number',
    'name',
    'year',
    'author',
    'action',
  ];

  constructor(private readonly bookService: BookService) {}

  public ngOnInit(): void {
    this.loadBooks();
  }

  public loadBooks(): void {
    this.bookService
      .getPagedBooks(
        this.currentPage,
        this.pageSize,
        this.isAscending,
        this.activeColumn,
        this.filterValue
      )
      .subscribe((result) => {
        this.dataSource = result.items;
        this.totalRows = result.totalCount;
      });
  }

  public pageChanged(event: PageEvent): void {
    this.pageSize = event.pageSize;
    this.currentPage = event.pageIndex + 1;

    this.loadBooks();
  }

  public deleteBook(id: number): void {
    this.bookService.deleteBook(id).subscribe(() => {
      this.currentPage = 1;

      this.loadBooks();
    });
  }

  public filterData(): void {
    this.currentPage = 1;

    this.loadBooks();
  }

  public sortData(sort: Sort): void {
    this.isAscending = sort.direction === 'asc';
    this.activeColumn = sort.active;

    this.loadBooks();
  }
}
