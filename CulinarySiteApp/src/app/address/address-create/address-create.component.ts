import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AddressService } from 'src/app/services/address.service';
import { CreateAddressModel } from 'src/app/viewmodels/address/create-address-model.class';

@Component({
  selector: 'app-address-create',
  templateUrl: './address-create.component.html',
  styleUrls: ['./address-create.component.css'],
})
export class AddressCreateComponent implements OnInit {
  public createAddressModel: CreateAddressModel = new CreateAddressModel();
  public addressForm: FormGroup;

  public constructor(
    private readonly addressService: AddressService,
    private readonly router: Router,
    private readonly fb: FormBuilder
  ) {}

  public ngOnInit(): void {
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
