import { IRestaurantDetailModel } from 'src/app/interfaces/restaurant/restaurant-detail-model.interface';
import { TelephoneDetailModel } from '../telephone/telephone-detail-model.class';

export class RestaurantDetailModel {
  public restaurantId: number;
  public name: string;
  public addressId: number;
  public telephones: TelephoneDetailModel[];

  constructor(public restaurantDetailModel?: IRestaurantDetailModel) {
    if (restaurantDetailModel) {
      this.restaurantId = restaurantDetailModel.restaurantId;
      this.name = restaurantDetailModel.name;
      this.addressId = restaurantDetailModel.addressId;
      this.telephones = restaurantDetailModel.telephones;
    }
  }
}
