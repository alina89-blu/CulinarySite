import { TelephoneModel } from 'src/app/viewmodels/telephone/telephone-model.class';

export interface IRestaurantDetailModel {
  restaurantId: number;
  name: string;
  addressId: number;
  telephones: TelephoneModel[];
}
