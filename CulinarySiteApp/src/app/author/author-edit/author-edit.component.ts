import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { AuthorService } from 'src/app/services/author.service';
import { UpdateAuthorModel } from 'src/app/viewmodels/author/update-author-model.class';
import { IAuthorDetailModel } from 'src/app/interfaces/author/author-detail-model.interface';
import {
  FormArray,
  FormBuilder,
  FormControl,
  FormGroup,
  Validators,
} from '@angular/forms';
import { BookModel } from 'src/app/viewmodels/book/book-model.class';
import { BookService } from 'src/app/services/book.service';
import { IBookModel } from 'src/app/interfaces/book/book-model.interface';

@Component({
  selector: 'app-author-edit',
  templateUrl: './author-edit.component.html',
  styleUrls: ['./author-edit.component.css'],
})
export class AuthorEditComponent implements OnInit {
  public id: number;
  public updateAuthorModel: UpdateAuthorModel = new UpdateAuthorModel();
  public books: BookModel[] = [];

  myForm: FormGroup; //

  constructor(
    private authorService: AuthorService,
    private bookService: BookService,
    private router: Router,
    activeRoute: ActivatedRoute,
    private fb: FormBuilder
  ) {
    this.id = Number.parseInt(activeRoute.snapshot.params['id']);

    this.myForm = new FormGroup({
      books: new FormArray([new FormControl('', Validators.required)]),
    });
    this.updateAuthorModel.books = [new BookModel()];
  }

  public getFormsControls(): FormArray {
    return this.myForm.controls['books'] as FormArray;
  }

  public addBook(): void {
    (<FormArray>this.myForm.controls['books']).push(
      new FormControl('', Validators.required)
    );
    this.updateAuthorModel.books.push(new BookModel());
  }

  public ngOnInit(): void {
    if (this.id) {
      this.authorService
        .getAuthor(this.id, true)
        .subscribe(
          (data: IAuthorDetailModel) =>
            (this.updateAuthorModel = new UpdateAuthorModel(data))
        );
    }

    this.getBookList();
  }

  public updateAuthor(): void {
    this.authorService
      .updateAuthor(this.updateAuthorModel)
      .subscribe(() => this.router.navigateByUrl('author'));
  }

  public getBookList(): void {
    this.bookService
      .getBookList()
      .subscribe(
        (data: IBookModel[]) => (this.books = data.map((x) => new BookModel(x)))
      );
  }

  public deleteBook(book: BookModel) {
    this.getFormsControls().removeAt(book.bookId);
  }
}
