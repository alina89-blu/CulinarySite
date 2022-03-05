import { ICommentDetailModel } from 'src/app/interfaces/comment/comment-detail-model.interface';
import { IUpdateCommentModel } from 'src/app/interfaces/comment/update-comment-model.interface';

export class UpdateCommentModel {
  public commentId: number;
  public content: string;
  public subscriberId: number; //???

  constructor(
    public updateCommentModel?: IUpdateCommentModel | ICommentDetailModel
  ) {
    if (updateCommentModel) {
      this.commentId = updateCommentModel.commentId;
      this.content = updateCommentModel.content;
      this.subscriberId = updateCommentModel.subscriberId;
    }
  }
}
