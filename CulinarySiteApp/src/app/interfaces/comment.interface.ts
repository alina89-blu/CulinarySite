import { Restaurant } from '../viewmodels/restaurant.class';
import { Subscriber } from '../viewmodels/subscriber.class';

export interface IComment {
  id: number;
  content: string;
  restaurants: Restaurant[];
  subscriberId: number;
  subscriber: Subscriber;
}
