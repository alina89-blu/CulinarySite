import { IAuthorDetailModel } from 'src/app/interfaces/author/author-detail-model.interface';
import { IUpdateAuthorModel } from 'src/app/interfaces/author/update-author-model.interface';
import { BookModel } from '../book/book-model.class';

export class UpdateAuthorModel {
  public authorId: number;
  public name: string;
  public books: BookModel[];

  constructor(
    public updateAuthorModel?: IUpdateAuthorModel | IAuthorDetailModel
  ) {
    if (updateAuthorModel) {
      this.authorId = updateAuthorModel.authorId;
      this.name = updateAuthorModel.name;
      this.books = updateAuthorModel.books;
    }
  }
}
