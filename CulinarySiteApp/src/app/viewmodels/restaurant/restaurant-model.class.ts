import { IRestaurantModel } from 'src/app/interfaces/restaurant/restaurant-model.interface';

export class RestaurantModel {
  public restaurantId: number;
  public name: string;

  constructor(public restaurantModel?: IRestaurantModel) {
    if (restaurantModel) {
      this.restaurantId = restaurantModel.restaurantId;
      this.name = restaurantModel.name;
    }
  }
}
