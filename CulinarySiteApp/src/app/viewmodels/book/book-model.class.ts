import { IBookModel } from 'src/app/interfaces/book/book-model.interface';

export class BookModel {
  public bookId: number;
  public name: string;

  constructor(public bookModel?: IBookModel) {
    if (bookModel) {
      this.bookId = bookModel.bookId;
      this.name = bookModel.name;
    }
  }
}
