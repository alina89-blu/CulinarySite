import { ICreateCommentModel } from 'src/app/interfaces/comment/create-comment-model.interface';

export class CreateCommentModel {
  public content: string;
  public subscriberId: number;

  constructor(public createCommentModel?: ICreateCommentModel) {
    if (createCommentModel) {
      this.content = createCommentModel.content;
      this.subscriberId = createCommentModel.subscriberId;
    }
  }
}
