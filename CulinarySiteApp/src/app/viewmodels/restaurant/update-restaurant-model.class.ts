import { IRestaurantDetailModel } from 'src/app/interfaces/restaurant/restaurant-detail-model.interface';
import { IUpdateRestaurantModel } from 'src/app/interfaces/restaurant/update-restaurant-model.interface';

export class UpdateRestaurantModel {
  public restaurantId: number;
  public name: string;
  public addressId: number;

  constructor(
    public updateRestaurantModel?:
      | IUpdateRestaurantModel
      | IRestaurantDetailModel
  ) {
    if (updateRestaurantModel) {
      this.restaurantId = updateRestaurantModel.restaurantId;
      this.name = updateRestaurantModel.name;
      this.addressId = updateRestaurantModel.addressId;
    }
  }
}
