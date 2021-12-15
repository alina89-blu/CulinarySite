import { Restaurant } from '../viewmodels/restaurant.class';

export interface ITelephone {
  id: number;
  number: string;
  restaurantId: number;
  restaurant: Restaurant;
}
