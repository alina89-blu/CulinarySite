import { Component, OnInit } from '@angular/core';
import { AuthorService } from 'src/app/services/author.service';
import { Router } from '@angular/router';
import { CreateAuthorModel } from 'src/app/viewmodels/author/create-author-model.class';
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
import { IAuthorDetailModel } from 'src/app/interfaces/author/author-detail-model.interface';

@Component({
  selector: 'app-author-create',
  templateUrl: './author-create.component.html',
  styleUrls: ['./author-create.component.css'],
})
export class AuthorCreateComponent {
  public createAuthorModel: CreateAuthorModel = new CreateAuthorModel();
  public books: BookModel[] = [];

  myForm: FormGroup; //

  constructor(
    private authorService: AuthorService,
    private router: Router,
    private bookService: BookService,
    private fb: FormBuilder
  ) {
    this.myForm = this.fb.group({
      // books: new FormControl(this.createAuthorModel.books),
      /*  books: new FormArray([new FormControl(this.createAuthorModel.books)
    });*/

      books: this.fb.array([]),
    });
    this.createAuthorModel.books = [new BookModel()];
  }

  public ngOnInit(): void {
    this.getBookList();
  }

  public getFormsControls(): FormArray {
    return this.myForm.controls['books'] as FormArray;
  }

  public addBook(): void {
    (<FormArray>this.myForm.controls['books']).push(
      new FormControl('', Validators.required)
    );
    this.createAuthorModel.books.push(new BookModel());
  }

  public createAuthor(): void {
    this.authorService
      .createAuthor(this.createAuthorModel)
      .subscribe(() => this.router.navigateByUrl('author'));
  }

  public getBookList(): void {
    this.bookService
      .getBookList()
      .subscribe(
        (data: IBookModel[]) => (this.books = data.map((x) => new BookModel(x)))
      );
  }

  public deleteBook(i: number) {
    this.getFormsControls().removeAt(i);
  }

  public setOrderItemArray() {
    const orderItemsArray = this.myForm.get('books') as FormArray;
    this.books.forEach((item) => {
      orderItemsArray.push(this.buildOrderItemsForm(item));
    });
    // this.createAuthorModel.books.push(new BookModel());
  }

  public buildOrderItemsForm(item: BookModel): FormGroup {
    return this.fb.group({
      id: item.bookId,
      name: item.name,
    });
  }
}
