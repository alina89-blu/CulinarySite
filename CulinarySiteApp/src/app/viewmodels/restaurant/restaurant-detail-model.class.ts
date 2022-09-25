import { IRestaurantDetailModel } from 'src/app/interfaces/restaurant/restaurant-detail-model.interface';
import { TelephoneModel } from '../telephone/telephone-model.class';

export class RestaurantDetailModel {
  public restaurantId: number;
  public name: string;
  public addressId: number;
  public telephones: TelephoneModel[];

  constructor(public restaurantDetailModel?: IRestaurantDetailModel) {
    if (restaurantDetailModel) {
      this.restaurantId = restaurantDetailModel.restaurantId;
      this.name = restaurantDetailModel.name;
      this.addressId = restaurantDetailModel.addressId;
      this.telephones = restaurantDetailModel.telephones;
    }
  }
}
