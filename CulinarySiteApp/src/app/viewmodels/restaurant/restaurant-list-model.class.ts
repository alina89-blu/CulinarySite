import { IRestaurantListModel } from 'src/app/interfaces/restaurant/restaurant-list-model.interface';
import { TelephoneDetailModel } from '../telephone/telephone-detail-model.class';

export class RestaurantListModel {
  public restaurantId: number;
  public name: string;
  public addressName: string;
  public telephones: TelephoneDetailModel[];

  constructor(public restaurantListModel?: IRestaurantListModel) {
    if (restaurantListModel) {
      this.restaurantId = restaurantListModel.restaurantId;
      this.name = restaurantListModel.name;
      this.addressName = restaurantListModel.addressName;
      this.telephones = restaurantListModel.telephones;
    }
  }
}
