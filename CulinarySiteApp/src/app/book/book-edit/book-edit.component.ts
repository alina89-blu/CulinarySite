import { Component, OnInit } from '@angular/core';
import { BookService } from 'src/app/services/book.service';
import { ActivatedRoute, Router } from '@angular/router';
import { AuthorService } from 'src/app/services/author.service';
import { AuthorListModel } from 'src/app/viewmodels/author/author-list-model.class';
import { IAuthorListModel } from 'src/app/interfaces/author/author-list-model.interface';
import { UpdateBookModel } from 'src/app/viewmodels/book/update-book-model.class';
import { IBookDetailModel } from 'src/app/interfaces/book/book-detail-model.interface';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-book-edit',
  templateUrl: './book-edit.component.html',
  styleUrls: ['./book-edit.component.css'],
})
export class BookEditComponent implements OnInit {
  private id: number;
  public updateBookModel: UpdateBookModel = new UpdateBookModel();
  public authors: AuthorListModel[] = [];
  public bookForm: FormGroup;

  constructor(
    private readonly bookService: BookService,
    private readonly authorService: AuthorService,
    private readonly router: Router,
    private readonly fb: FormBuilder,
    activeRoute: ActivatedRoute
  ) {
    this.id = Number.parseInt(activeRoute.snapshot.params['id']);
  }

  public ngOnInit(): void {
    if (this.id) {
      this.bookService
        .getBook(this.id, true)
        .subscribe(
          (data: IBookDetailModel) =>
            (this.updateBookModel = new UpdateBookModel(data))
        );
    }

    this.bookForm = this.fb.group({
      name: ['', [Validators.required, Validators.minLength(5)]],
      creationYear: ['', [Validators.required, Validators.min(1990)]],
      description: ['', Validators.required],
      imageUrl: ['', Validators.required],
      authorId: ['', Validators.required],
    });

    this.getAuthorList();
  }

  public updateBook(): void {
    this.bookService
      .updateBook(this.updateBookModel)
      .subscribe(() => this.router.navigateByUrl('book'));
  }

  public getAuthorList(): void {
    this.authorService
      .getAuthorList()
      .subscribe(
        (data: IAuthorListModel[]) =>
          (this.authors = data.map((x) => new AuthorListModel(x)))
      );
  }
}
