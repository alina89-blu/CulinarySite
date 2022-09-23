import { IAuthorListModel } from 'src/app/interfaces/author/author-list-model.interface';

export class AuthorListModel {
  public authorId: number;
  public name: string;

  constructor(public authorListModel?: IAuthorListModel) {
    if (authorListModel) {
      this.authorId = authorListModel.authorId;
      this.name = authorListModel.name;
    }
  }
}
