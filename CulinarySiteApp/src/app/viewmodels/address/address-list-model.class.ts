import { IAddressListModel } from 'src/app/interfaces/address/address-list-model.interface';

export class AddressListModel {
  public id: number;
  public name: string;

  constructor(public addressListModel?: IAddressListModel) {
    if (addressListModel) {
      this.id = addressListModel.id;
      this.name = addressListModel.name;
    }
  }
}
