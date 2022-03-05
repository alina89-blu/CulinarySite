import { ICreateRestaurantModel } from 'src/app/interfaces/restaurant/create-restaurant-model.interface';

export class CreateRestaurantModel {
  public name: string;
  public addressId: number;

  constructor(public createRestaurantModel?: ICreateRestaurantModel) {
    if (createRestaurantModel) {
      this.name = createRestaurantModel.name;
      this.addressId = createRestaurantModel.addressId;
    }
  }
}
