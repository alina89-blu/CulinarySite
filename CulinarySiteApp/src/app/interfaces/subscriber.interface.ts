import { Comment } from '../viewmodels/comment.class';

export interface ISubscriber {
  id: number;
  name: string;
  email: string;
  comments: Comment[];
}
