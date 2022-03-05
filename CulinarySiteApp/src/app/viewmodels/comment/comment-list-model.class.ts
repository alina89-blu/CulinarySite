import { ICommentListModel } from '../../interfaces/comment/comment-list-model.interface';

export class CommentListModel {
  public commentId: number;
  public content: string;
  public subscriberName: number;

  constructor(public commentListModel?: ICommentListModel) {
    if (commentListModel) {
      this.commentId = commentListModel.commentId;
      this.content = commentListModel.content;
      this.subscriberName = commentListModel.subscriberName;
    }
  }
}
