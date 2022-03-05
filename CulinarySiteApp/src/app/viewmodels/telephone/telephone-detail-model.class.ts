import { ITelephoneDetailModel } from 'src/app/interfaces/telephone/telephone-detail-model.interface';

export class TelephoneDetailModel {
  public telephoneId: number;
  public number: string;
  public restaurantId: number;

  constructor(public telephoneDetailModel?: ITelephoneDetailModel) {
    if (telephoneDetailModel) {
      this.telephoneId = telephoneDetailModel.telephoneId;
      this.number = telephoneDetailModel.number;
      this.restaurantId = telephoneDetailModel.restaurantId;
    }
  }
}
