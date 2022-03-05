import { IAddressDetailModel } from 'src/app/interfaces/address/address-detail-model.interface';

export class AddressDetailModel {
  public id: number;
  public name: string;

  constructor(public addressDetailModel?: IAddressDetailModel) {
    if (addressDetailModel) {
      this.id = addressDetailModel.id;
      this.name = addressDetailModel.name;
    }
  }
}
