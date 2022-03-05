import { TelephoneDetailModel } from 'src/app/viewmodels/telephone/telephone-detail-model.class';

export interface IRestaurantDetailModel {
  restaurantId: number;
  name: string;
  addressId: number;
  telephones: TelephoneDetailModel[];
}
