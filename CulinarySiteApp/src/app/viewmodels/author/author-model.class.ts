import { IAuthorModel } from 'src/app/interfaces/author/author-model.interface';

export class AuthorModel {
  public authorId: number;
  public name: string;

  constructor(public authorModel?: IAuthorModel) {
    if (authorModel) {
      this.authorId = authorModel.authorId;
      this.name = authorModel.name;
    }
  }
}
