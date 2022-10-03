import { IAddressDetailModel } from 'src/app/interfaces/address/address-detail-model.interface';

export class AddressDetailModel {
  public addressId: number;
  public name: string;

  constructor(public addressDetailModel?: IAddressDetailModel) {
    if (addressDetailModel) {
      this.addressId = addressDetailModel.addressId;
      this.name = addressDetailModel.name;
    }
  }
}
