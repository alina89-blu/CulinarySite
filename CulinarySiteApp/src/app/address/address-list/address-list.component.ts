import { Component, OnInit } from '@angular/core';
import { AddressService } from '../../services/address.service';
import { AddressListModel } from 'src/app/viewmodels/address/address-list-model.class';
import { IAddressListModel } from 'src/app/interfaces/address/address-list-model.interface';

@Component({
  selector: 'app-address',
  templateUrl: './address-list.component.html',
  styleUrls: ['./address-list.component.css'],
  providers: [AddressService],
})
export class AddressListComponent implements OnInit {
  addresses: AddressListModel[] = [];

  constructor(private addressService: AddressService) {}

  public ngOnInit(): void {
    this.getAddressList();
  }

  public getAddressList(): void {
    this.addressService
      .getAddressList()
      .subscribe(
        (data: IAddressListModel[]) =>
          (this.addresses = data.map((x) => new AddressListModel(x)))
      );
  }

  public deleteAddress(id: number) {
    this.addressService.delete(id).subscribe(() => this.getAddressList());
  }
}
