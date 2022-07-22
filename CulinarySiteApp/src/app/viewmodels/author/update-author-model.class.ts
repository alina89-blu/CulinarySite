import { IAuthorDetailModel } from 'src/app/interfaces/author/author-detail-model.interface';
import { IUpdateAuthorModel } from 'src/app/interfaces/author/update-author-model.interface';

export class UpdateAuthorModel {
  public authorId: number;
  public name: string;

  constructor(
    public updateAuthorModel?: IUpdateAuthorModel | IAuthorDetailModel
  ) {
    if (updateAuthorModel) {
      this.authorId = updateAuthorModel.authorId;
      this.name = updateAuthorModel.name;
    }
  }
}
