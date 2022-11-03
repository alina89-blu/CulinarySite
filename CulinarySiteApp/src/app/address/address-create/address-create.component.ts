import { Component } from '@angular/core';
import { AddressService } from 'src/app/services/address.service';
import { Router } from '@angular/router';
import { CreateAddressModel } from 'src/app/viewmodels/address/create-address-model.class';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-address-create',
  templateUrl: './address-create.component.html',
  styleUrls: ['./address-create.component.css'],
})
export class AddressCreateComponent {
  public createAddressModel: CreateAddressModel = new CreateAddressModel();
  public addressForm: FormGroup;
  constructor(
    private addressService: AddressService,
    private router: Router,
    private fb: FormBuilder
  ) {
    this.addressForm = this.fb.group({
      name: ['', [Validators.required, Validators.minLength(5)]],
    });
  }

  public createAddress(): void {
    this.addressService
      .createAddress(this.createAddressModel)
      .subscribe(() => this.router.navigateByUrl('address'));
  }
}
