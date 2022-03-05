import { ICommentDetailModel } from 'src/app/interfaces/comment/comment-detail-model.interface';

export class CommentDetailModel {
  public commentId: number;
  public content: string;
  public subscriberId: number;

  constructor(public commentDetailModel?: ICommentDetailModel) {
    if (commentDetailModel) {
      this.commentId = commentDetailModel.commentId;
      this.content = commentDetailModel.content;
      this.subscriberId = commentDetailModel.subscriberId;
    }
  }
}
