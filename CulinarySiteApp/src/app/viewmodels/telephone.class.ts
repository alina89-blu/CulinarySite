import { Restaurant } from './restaurant.class';
import { ITelephone } from '../interfaces/telephone.interface';

export class Telephone {
  public id: number;
  public number: string;
  public restaurantId: number;
  public restaurant: Restaurant;

  constructor(public telephone?: ITelephone) {
    if (telephone) {
      this.id = telephone.id;
      this.number = telephone.number;
      this.restaurantId = telephone.restaurantId;
      this.restaurant = telephone.restaurant;
    }
  }
}
