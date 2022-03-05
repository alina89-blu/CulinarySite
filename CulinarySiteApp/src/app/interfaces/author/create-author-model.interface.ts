import { BookModel } from 'src/app/viewmodels/book/book-model.class';

export interface ICreateAuthorModel {
  name: string;
  books: BookModel[];
}
