import { ITelephoneModel } from 'src/app/interfaces/telephone/telephone-model.interface';

export class TelephoneModel {
  public telephoneId: number;
  public number: string;

  constructor(public telephoneModel?: ITelephoneModel) {
    if (telephoneModel) {
      this.telephoneId = telephoneModel.telephoneId;
      this.number = telephoneModel.number;
    }
  }
}
