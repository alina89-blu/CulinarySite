import { TelephoneModel } from 'src/app/viewmodels/telephone/telephone-model.class';

export interface IRestaurantListModel {
  restaurantId: number;
  name: string;
  addressName: string;
  telephones: TelephoneModel[];
}
