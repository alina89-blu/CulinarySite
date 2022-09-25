import { IRestaurantListModel } from 'src/app/interfaces/restaurant/restaurant-list-model.interface';
import { TelephoneModel } from '../telephone/telephone-model.class';

export class RestaurantListModel {
  public restaurantId: number;
  public name: string;
  public addressName: string;
  public telephones: TelephoneModel[];

  constructor(public restaurantListModel?: IRestaurantListModel) {
    if (restaurantListModel) {
      this.restaurantId = restaurantListModel.restaurantId;
      this.name = restaurantListModel.name;
      this.addressName = restaurantListModel.addressName;
      this.telephones = restaurantListModel.telephones;
    }
  }
}
