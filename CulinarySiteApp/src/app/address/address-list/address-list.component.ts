import { Component, OnInit } from '@angular/core';
import { Address } from 'src/app/viewmodels/address.class';
import { IAddress } from 'src/app/interfaces/address.interface';
import { AddressService } from '../../services/address.service';

@Component({
  selector: 'app-address',
  templateUrl: './address-list.component.html',
  styleUrls: ['./address-list.component.css'],
  providers: [AddressService],
})
export class AddressListComponent implements OnInit {
  addresses: Address[] = [];

  constructor(private addressService: AddressService) {}

  public ngOnInit(): void {
    this.getAddressList();
  }

  public getAddressList(): void {
    this.addressService
      .getAddressList()
      .subscribe(
        (data: IAddress[]) => (this.addresses = data.map((x) => new Address(x)))
      );
  }

  public deleteAddress(id: number) {
    this.addressService.delete(id).subscribe(() => this.getAddressList());
  }
}
