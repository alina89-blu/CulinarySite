import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Address } from 'src/app/viewmodels/address.class';
import { IAddress } from 'src/app/interfaces/address.interface';
import { AddressService } from 'src/app/services/address.service';

@Component({
  selector: 'app-address-edit',
  templateUrl: './address-edit.component.html',
  styleUrls: ['./address-edit.component.css'],
})
export class AddressEditComponent implements OnInit {
  private id: number;
  // public address: Address;
  public address: Address = new Address();

  constructor(
    private addressService: AddressService,
    private router: Router,
    activeRoute: ActivatedRoute
  ) {
    this.id = Number.parseInt(activeRoute.snapshot.params['id']);
  }

  public ngOnInit(): void {
    if (this.id) {
      this.addressService
        .getAddress(this.id)
        .subscribe((data: IAddress) => (this.address = new Address(data)));
    }
  }

  public updateAddress(): void {
    this.addressService
      .updateAddress(this.address)
      .subscribe(() => this.router.navigateByUrl('address'));
  }
}
