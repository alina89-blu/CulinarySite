import { ISubscriberDetailModel } from 'src/app/interfaces/subscriber/subscriber-detail-model.interface';
import { Comment } from '../comment.class';

export class SubscriberDetailModel {
  public subscriberId: number;
  public name: string;
  public email: string;
  // public comments: Comment[];

  constructor(public subscriberDetailModel?: ISubscriberDetailModel) {
    if (subscriberDetailModel) {
      this.subscriberId = subscriberDetailModel.subscriberId;
      this.name = subscriberDetailModel.name;
      this.email = subscriberDetailModel.email;
      // this.comments = subscriberDetailModel.comments;
    }
  }
}
