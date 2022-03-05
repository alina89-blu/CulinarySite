import { IAddressDetailModel } from 'src/app/interfaces/address/address-detail-model.interface';
import { IUpdateAddressModel } from 'src/app/interfaces/address/update-address-model.interface';

export class UpdateAddressModel {
  public id: number;
  public name: string;

  constructor(
    public updateAddressModel?: IUpdateAddressModel | IAddressDetailModel
  ) {
    if (updateAddressModel) {
      this.id = updateAddressModel.id;
      this.name = updateAddressModel.name;
    }
  }
}
