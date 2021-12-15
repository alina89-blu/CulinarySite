import { IComment } from '../interfaces/comment.interface';
import { Restaurant } from './restaurant.class';
import { Subscriber } from './subscriber.class';

export class Comment {
  public id: number;
  public content: string;
  public restaurants: Restaurant[];
  public subscriberId: number;
  public subscriber: Subscriber;

  constructor(public comment?: IComment) {
    if (comment) {
      this.id = comment.id;
      this.content = comment.content;
      this.restaurants = comment.restaurants;
      this.subscriberId = comment.subscriberId;
      this.subscriber = comment.subscriber;
    }
  }
}
