import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { IBookDetailModel } from 'src/app/interfaces/book/book-detail-model.interface';
import { BookService } from 'src/app/services/book.service';
import { BookDetailModel } from 'src/app/viewmodels/book/book-detail-model.class';

@Component({
  selector: 'app-book-detail',
  templateUrl: './book-detail.component.html',
  styleUrls: ['./book-detail.component.css'],
})
export class BookDetailComponent implements OnInit {
  private id: number;
  public bookDetailModel: BookDetailModel = new BookDetailModel();

  constructor(
    private readonly bookService: BookService,
    activeRoute: ActivatedRoute
  ) {
    this.id = Number.parseInt(activeRoute.snapshot.params['id']);
  }

  ngOnInit(): void {
    if (this.id) {
      this.bookService
        .getBook(this.id, true)
        .subscribe(
          (data: IBookDetailModel) =>
            (this.bookDetailModel = new BookDetailModel(data))
        );
    }
  }
}
