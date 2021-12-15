import { Comment } from './comment.class';
import { ISubscriber } from '../interfaces/subscriber.interface';

export class Subscriber {
  public id: number;
  public name: string;
  public email: string;
  public comments: Comment[];

  constructor(public subscriber?: ISubscriber) {
    if (subscriber) {
      this.id = subscriber.id;
      this.name = subscriber.name;
      this.email = subscriber.email;
      this.comments = subscriber.comments;
    }
  }
}
