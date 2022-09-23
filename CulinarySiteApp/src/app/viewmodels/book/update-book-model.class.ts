import { IBookDetailModel } from 'src/app/interfaces/book/book-detail-model.interface';
import { IUpdateBookModel } from 'src/app/interfaces/book/update-book-model.interface';

export class UpdateBookModel {
  public bookId: number;
  public authorId: number;
  public name: string;
  public creationYear: number;
  public description: string;

  constructor(public updateBookModel?: IUpdateBookModel | IBookDetailModel) {
    if (updateBookModel) {
      this.bookId = updateBookModel.bookId;
      this.authorId = updateBookModel.authorId;
      this.name = updateBookModel.name;
      this.creationYear = updateBookModel.creationYear;
      this.description = updateBookModel.description;
    }
  }
}
