import { Restaurant } from '../viewmodels/restaurant.class';

export interface IAddress {
  id: number;
  name: string;
  restaurants: Restaurant[];
}
