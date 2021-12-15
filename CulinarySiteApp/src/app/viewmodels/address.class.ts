import { IAddress } from '../interfaces/address.interface';
import { Restaurant } from './restaurant.class';

export class Address {
  public id: number;
  public name: string;
  public restaurants: Restaurant[];

  constructor(public adress?: IAddress) {
    if (adress) {
      this.id = adress.id;
      this.name = adress.name;
      this.restaurants = adress.restaurants;
    }
  }
}
