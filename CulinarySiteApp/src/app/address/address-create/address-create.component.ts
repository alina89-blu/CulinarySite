import { Component } from '@angular/core';
import { AddressService } from 'src/app/services/address.service';
import { Router } from '@angular/router';
import { Address } from 'src/app/viewmodels/address.class';

@Component({
  selector: 'app-address-create',

  templateUrl: './address-create.component.html',
  styleUrls: ['./address-create.component.css'],
})
export class AddressCreateComponent {
  public address: Address = new Address();

  constructor(private addressService: AddressService, private router: Router) {}

  public createAddress(): void {
    this.addressService
      .createAddress(this.address)
      .subscribe(() => this.router.navigateByUrl('address'));
  }
}
