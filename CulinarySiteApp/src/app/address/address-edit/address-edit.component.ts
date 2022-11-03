import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { AddressService } from 'src/app/services/address.service';
import { UpdateAddressModel } from 'src/app/viewmodels/address/update-address-model.class';
import { IAddressDetailModel } from 'src/app/interfaces/address/address-detail-model.interface';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-address-edit',
  templateUrl: './address-edit.component.html',
  styleUrls: ['./address-edit.component.css'],
})
export class AddressEditComponent implements OnInit {
  private id: number;
  public updateAddressModel: UpdateAddressModel = new UpdateAddressModel();
  public addressForm: FormGroup;

  constructor(
    private addressService: AddressService,
    private router: Router,
    private fb: FormBuilder,
    activeRoute: ActivatedRoute
  ) {
    this.id = Number.parseInt(activeRoute.snapshot.params['id']);
    this.addressForm = this.fb.group({
      name: ['', [Validators.required, Validators.minLength(5)]],
    });
  }

  public ngOnInit(): void {
    if (this.id) {
      this.addressService
        .getAddress(this.id)
        .subscribe(
          (data: IAddressDetailModel) =>
            (this.updateAddressModel = new UpdateAddressModel(data))
        );
    }
  }

  public updateAddress(): void {
    this.addressService
      .updateAddress(this.updateAddressModel)
      .subscribe(() => this.router.navigateByUrl('address'));
  }
}
