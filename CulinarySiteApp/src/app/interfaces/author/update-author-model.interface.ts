import { BookModel } from 'src/app/viewmodels/book/book-model.class';

export interface IUpdateAuthorModel {
  authorId: number;
  name: string;
  books: BookModel[];
}
