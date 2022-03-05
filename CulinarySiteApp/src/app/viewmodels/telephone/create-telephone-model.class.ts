import { ICreateTelephoneModel } from 'src/app/interfaces/telephone/create-telephone-model.interface';

export class CreateTelephoneModel {
  public number: string;
  public restaurantId: number;

  constructor(public createTelephoneModel?: ICreateTelephoneModel) {
    if (createTelephoneModel) {
      this.number = createTelephoneModel.number;
      this.restaurantId = createTelephoneModel.restaurantId;
    }
  }
}
