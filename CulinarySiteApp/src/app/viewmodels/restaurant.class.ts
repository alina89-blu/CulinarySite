import { Comment } from './comment.class';
import { Address } from './address.class';
import { IRestaurant } from '../interfaces/restaurant.interface';
import { Telephone } from './telephone.class';

export class Restaurant {
  public id: number;
  public name: string;
  public telephones: Telephone[];
  public comments: Comment[];
  public addressId: number;
  public address: Address;

  constructor(public restaurant?: IRestaurant) {
    if (restaurant) {
      this.id = restaurant.id;
      this.name = restaurant.name;
      this.telephones = restaurant.telephones;
      this.comments = restaurant.comments;
      this.addressId = restaurant.addressId;
      this.address = restaurant.address;
    }
  }
}
