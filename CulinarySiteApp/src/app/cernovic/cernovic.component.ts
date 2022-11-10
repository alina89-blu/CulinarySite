import { Component, OnInit } from '@angular/core';
import { PageEvent } from '@angular/material/paginator';
import { IBookDetailListModel } from '../interfaces/book/book-detail-list-model.interface';
import { BookService } from '../services/book.service';

@Component({
  selector: 'app-cernovic',
  templateUrl: './cernovic.component.html',
  styleUrls: ['./cernovic.component.css'],
})
export class CernovicComponent implements OnInit {
  public totalRows: number = 0;
  public pageSize: number = 5;
  public currentPage: number = 1;
  public pageSizeOptions: number[] = [3, 5, 10, 25];

  dataSource: IBookDetailListModel[];
  displayedColumns: string[] = ['number', 'name', 'year', 'author', 'action'];

  constructor(private bookService: BookService) {}

  public ngOnInit(): void {
    this.loadBooks();
  }

  public loadBooks() {
    // this.bookService
    //   .getPagedBooks(this.currentPage, this.pageSize)
    //   .subscribe((result) => {
    //     this.dataSource = result.items;
    //     this.totalRows = result.totalCount;
    //   });
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
}
