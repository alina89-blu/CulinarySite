import { IBookDetailModel } from 'src/app/interfaces/book/book-detail-model.interface';

export class BookDetailModel {
  public bookId?: number;
  public authorId: number;
  public name: string;
  public creationYear: Date = new Date();
  public description: string;

  constructor(public bookDetailModel?: IBookDetailModel) {
    if (bookDetailModel) {
      this.bookId = bookDetailModel.bookId;
      this.authorId = bookDetailModel.authorId;
      this.name = bookDetailModel.name;
      this.creationYear = bookDetailModel.creationYear;
      this.description = bookDetailModel.description;
    }
  }
}
