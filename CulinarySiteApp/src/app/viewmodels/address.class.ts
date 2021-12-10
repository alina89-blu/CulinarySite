import { IAddress } from '../interfaces/address.interface';

export class Address {
  public id: number;
  public name: string;

  constructor(public adress?: IAddress) {
    if (adress) {
      this.id = adress.id;
      this.name = adress.name;
    }
  }
}
