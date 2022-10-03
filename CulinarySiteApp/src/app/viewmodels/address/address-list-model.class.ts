import { IAddressListModel } from 'src/app/interfaces/address/address-list-model.interface';

export class AddressListModel {
  public addressId: number;
  public name: string;

  constructor(public addressListModel?: IAddressListModel) {
    if (addressListModel) {
      this.addressId = addressListModel.addressId;
      this.name = addressListModel.name;
    }
  }
}
