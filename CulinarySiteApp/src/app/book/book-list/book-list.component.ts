import { AfterViewInit, Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { MatSort, Sort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { tap } from 'rxjs';
import { IBookDetailListModel } from 'src/app/interfaces/book/book-detail-list-model.interface';
import { IPagedList } from 'src/app/interfaces/common/paged-list';
import { BookService } from 'src/app/services/book.service';
import { BookDetailListModel } from 'src/app/viewmodels/book/book-detail-list-model.class';

@Component({
  selector: 'app-book-list',
  templateUrl: './book-list.component.html',
  styleUrls: ['./book-list.component.css'],
})
export class BookListComponent implements OnInit {
  public totalRows: number = 0;
  public pageSize: number = 5;
  public activeColumn: string;
  public isAscending: boolean = true;
  public currentPage: number = 1;
  public pageSizeOptions: number[] = [3, 5, 10, 25];

  dataSource: IBookDetailListModel[];
  displayedColumns: string[] = ['number', 'name', 'year', 'author', 'action'];

  constructor(private bookService: BookService) {}

  public ngOnInit(): void {
    this.loadBooks();
  }

  public loadBooks() {
    this.bookService
      .getPagedBooks(
        this.currentPage,
        this.pageSize,
        this.isAscending,
        this.activeColumn
      )
      .subscribe((result) => {
        this.dataSource = result.items;
        this.totalRows = result.totalCount;
      });
  }

  public pageChanged(event: PageEvent) {
    this.pageSize = event.pageSize;
    this.currentPage = event.pageIndex + 1;

    this.loadBooks();
  }

  public deleteBook(id: number) {
    this.bookService.deleteBook(id).subscribe(() => {
      this.currentPage = 1;

      this.loadBooks();
    });
  }

  public sortData(sort: Sort) {
    this.isAscending = sort.direction === 'asc';
    this.activeColumn = sort.active;

    this.loadBooks();
  }
}
