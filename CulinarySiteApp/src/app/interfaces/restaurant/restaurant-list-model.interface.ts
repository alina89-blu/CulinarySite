import { TelephoneDetailModel } from 'src/app/viewmodels/telephone/telephone-detail-model.class';

export interface IRestaurantListModel {
  restaurantId: number;
  name: string;
  addressName: string;
  telephones: TelephoneDetailModel[];
}
