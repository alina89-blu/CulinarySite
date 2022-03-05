import { IAuthorDetailModel } from 'src/app/interfaces/author/author-detail-model.interface';
import { BookModel } from '../book/book-model.class';

export class AuthorDetailModel {
  public authorId: number;
  public name: string;
  public books: BookModel[];

  constructor(public authorDetailModel?: IAuthorDetailModel) {
    if (authorDetailModel) {
      this.authorId = authorDetailModel.authorId;
      this.name = authorDetailModel.name;
      this.books = authorDetailModel.books;
    }
  }
}
