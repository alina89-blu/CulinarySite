import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { IAddressListModel } from 'src/app/interfaces/address/address-list-model.interface';
import { AddressService } from 'src/app/services/address.service';
import { RestaurantService } from 'src/app/services/restaurant.service';
import { AddressListModel } from 'src/app/viewmodels/address/address-list-model.class';
import { CreateRestaurantModel } from 'src/app/viewmodels/restaurant/create-restaurant-model.class';

@Component({
  selector: 'app-restaurant-create',
  templateUrl: './restaurant-create.component.html',
  styleUrls: ['./restaurant-create.component.css'],
})
export class RestaurantCreateComponent implements OnInit {
  public createRestaurantModel: CreateRestaurantModel =
    new CreateRestaurantModel();
  public addresses: AddressListModel[] = [];
  public restaurantForm: FormGroup;

  constructor(
    private restaurantService: RestaurantService,
    private router: Router,
    private addressService: AddressService,
    private fb: FormBuilder
  ) {
    this.restaurantForm = this.fb.group({
      name: ['', Validators.required],
      addressId: ['', Validators.required],
    });
  }

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

  public createRestaurant(): void {
    this.restaurantService
      .createRestaurant(this.createRestaurantModel)
      .subscribe(() => this.router.navigateByUrl('restaurant'));
  }
}
