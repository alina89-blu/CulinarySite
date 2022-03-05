import { ITelephoneListModel } from 'src/app/interfaces/telephone/telephone-list-model.interface';

export class TelephoneListModel {
  public telephoneId: number;
  public number: string;
  public restaurantName: string;

  constructor(public telephoneListModel?: ITelephoneListModel) {
    if (telephoneListModel) {
      this.telephoneId = telephoneListModel.telephoneId;
      this.number = telephoneListModel.number;
      this.restaurantName = telephoneListModel.restaurantName;
    }
  }
}
