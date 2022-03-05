import { Component } from '@angular/core';
import { FormGroup, FormControl, Validators, FormArray } from '@angular/forms';
import { IBookDetailListModel } from './interfaces/book/book-detail-list-model.interface';
import { IBookModel } from './interfaces/book/book-model.interface';
import { BookService } from './services/book.service';
import { BookDetailListModel } from './viewmodels/book/book-detail-list-model.class';
import { BookModel } from './viewmodels/book/book-model.class';

@Component({
  selector: 'my-app',
  /* styles: [
    `
      input.ng-touched.ng-invalid {
        border: solid red 2px;
      }
      input.ng-touched.ng-valid {
        border: solid green 2px;
      }
    `,
  ],*/
  template: `<form [formGroup]="myForm">
    <div formArrayName="phones">
      <div
        class="form-group"
        *ngFor="let phone of getFormsControls()['controls']; let i = index"
      >
        <label>Телефон</label>

        <select class="form-control" formControlName="{{ i }}">
          <option *ngFor="let book of books" [ngValue]="book.bookId">
            {{ book.name }}
          </option>
        </select>
      </div>
    </div>
    <div class="form-group">
      <button class="btn btn-default" (click)="addPhone()">
        Добавить телефон
      </button>
    </div>
  </form>`,
})
export class BlaComponent {
  myForm: FormGroup;
  books: BookModel[] = [];
  bla: string;

  constructor(private bookService: BookService) {
    this.myForm = new FormGroup({
      phones: new FormArray([new FormControl('', Validators.required)]),
    });
  }

  getFormsControls(): FormArray {
    return this.myForm.controls['phones'] as FormArray;
  }

  addPhone() {
    (<FormArray>this.myForm.controls['phones']).push(
      new FormControl('', Validators.required)
    );
  }

  public ngOnInit(): void {
    this.getBookListWithInclude();
  }

  public getBookListWithInclude(): void {
    this.bookService
      .getBookList()
      .subscribe(
        (data: IBookModel[]) => (this.books = data.map((x) => new BookModel(x)))
      );
  }
}
