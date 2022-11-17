import { Component, OnInit } from '@angular/core';
import { IBookDetailListModel } from '../interfaces/book/book-detail-list-model.interface';
import { BookService } from '../services/book.service';
import { BookDetailListModel } from '../viewmodels/book/book-detail-list-model.class';

@Component({
  selector: 'app-book-library',
  templateUrl: './book-library.component.html',
  styleUrls: ['./book-library.component.css'],
})
export class BookLibraryComponent implements OnInit {
  public books: BookDetailListModel[] = [];
  constructor(private readonly bookService: BookService) {}

  public ngOnInit(): void {
    this.getBookDetailList();
  }

  public getBookDetailList(): void {
    this.bookService
      .getBookDetailList(false)
      .subscribe(
        (data: IBookDetailListModel[]) =>
          (this.books = data.map((x) => new BookDetailListModel(x)))
      );
  }
}
