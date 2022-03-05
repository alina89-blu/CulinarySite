import { ITelephoneDetailModel } from 'src/app/interfaces/telephone/telephone-detail-model.interface';
import { IUpdateTelephoneModel } from 'src/app/interfaces/telephone/update-telephone-model.interface';

export class UpdateTelephoneModel {
  public telephoneId: number;
  public number: string;
  public restaurantId: number;

  constructor(
    public updateTelephoneModel?: IUpdateTelephoneModel | ITelephoneDetailModel
  ) {
    if (updateTelephoneModel) {
      this.telephoneId = updateTelephoneModel.telephoneId;
      this.number = updateTelephoneModel.number;
      this.restaurantId = updateTelephoneModel.restaurantId;
    }
  }
}
