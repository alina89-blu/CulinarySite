import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { BookService } from 'src/app/services/book.service';
import { AuthorService } from 'src/app/services/author.service';
import { AuthorListModel } from 'src/app/viewmodels/author/author-list-model.class';
import { IAuthorListModel } from 'src/app/interfaces/author/author-list-model.interface';
import { CreateBookModel } from 'src/app/viewmodels/book/create-book-model.class';

@Component({
  selector: 'app-book-create',
  templateUrl: './book-create.component.html',
  styleUrls: ['./book-create.component.css'],
})
export class BookCreateComponent implements OnInit {
  public createBookModel: CreateBookModel = new CreateBookModel();
  public authors: AuthorListModel[] = [];

  constructor(
    private bookService: BookService,
    private router: Router,
    private authorService: AuthorService
  ) {}

  public createBook(): void {
    this.bookService
      .createBook(this.createBookModel)
      .subscribe(() => this.router.navigateByUrl('book'));
  }
  public ngOnInit(): void {
    this.getAuthorList();
  }

  public getAuthorList(): void {
    this.authorService
      .getAuthorDetailList(false)
      .subscribe(
        (data: IAuthorListModel[]) =>
          (this.authors = data.map((x) => new AuthorListModel(x)))
      );
  }
}
