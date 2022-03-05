import { BookModel } from 'src/app/viewmodels/book/book-model.class';

export interface IAuthorDetailModel {
  authorId: number;
  name: string;
  books: BookModel[];
}
