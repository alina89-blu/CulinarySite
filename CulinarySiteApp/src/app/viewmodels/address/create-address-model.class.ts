import { ICreateAddressModel } from 'src/app/interfaces/address/create-address-model.interface';

export class CreateAddressModel {
  public name: string;

  constructor(public createAddressModel?: ICreateAddressModel) {
    if (createAddressModel) {
      this.name = createAddressModel.name;
    }
  }
}
