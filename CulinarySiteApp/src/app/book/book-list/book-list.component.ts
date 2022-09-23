import { Component, OnInit } from '@angular/core';
import { IBookDetailListModel } from 'src/app/interfaces/book/book-detail-list-model.interface';
import { BookService } from 'src/app/services/book.service';
import { BookDetailListModel } from 'src/app/viewmodels/book/book-detail-list-model.class';

@Component({
  selector: 'app-book-list',
  templateUrl: './book-list.component.html',
  styleUrls: ['./book-list.component.css'],
})
export class BookListComponent implements OnInit {
  public books: BookDetailListModel[] = [];

  constructor(private bookService: BookService) {}

  public ngOnInit(): void {
    this.getBookDetailList();
  }

  public getBookDetailList(): void {
    this.bookService
      .getBookDetailList(true)
      .subscribe(
        (data: IBookDetailListModel[]) =>
          (this.books = data.map((x) => new BookDetailListModel(x)))
      );
  }

  public deleteBook(id: number) {
    this.bookService.deleteBook(id).subscribe(() => this.getBookDetailList());
  }

  public sortBooksByName() {
    this.bookService
      .getSortedBooksByName(true)
      .subscribe(
        (data: IBookDetailListModel[]) =>
          (this.books = data.map((x) => new BookDetailListModel(x)))
      );
  }

  public sortBooksByYear() {
    this.bookService
      .getSortedBooksByYear(true)
      .subscribe(
        (data: IBookDetailListModel[]) =>
          (this.books = data.map((x) => new BookDetailListModel(x)))
      );
  }
}
