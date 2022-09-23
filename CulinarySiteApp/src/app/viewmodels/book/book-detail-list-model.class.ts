import { IBookDetailListModel } from 'src/app/interfaces/book/book-detail-list-model.interface';

export class BookDetailListModel {
  public bookId: number;
  public name: string;
  public creationYear: number;
  public authorName: string;
  public description: string;

  constructor(public bookDetailListModel?: IBookDetailListModel) {
    if (bookDetailListModel) {
      this.bookId = bookDetailListModel.bookId;
      this.name = bookDetailListModel.name;
      this.creationYear = bookDetailListModel.creationYear;
      this.authorName = bookDetailListModel.authorName;
      this.description = bookDetailListModel.description;
    }
  }
}
