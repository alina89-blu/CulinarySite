import { Component, OnInit } from '@angular/core';
import { FormControl, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { IAddressListModel } from 'src/app/interfaces/address/address-list-model.interface';
import { IRestaurantDetailModel } from 'src/app/interfaces/restaurant/restaurant-detail-model.interface';
import { AddressService } from 'src/app/services/address.service';
import { RestaurantService } from 'src/app/services/restaurant.service';
import { AddressListModel } from 'src/app/viewmodels/address/address-list-model.class';
import { UpdateRestaurantModel } from 'src/app/viewmodels/restaurant/update-restaurant-model.class';

@Component({
  selector: 'app-restaurant-edit',
  templateUrl: './restaurant-edit.component.html',
  styleUrls: ['./restaurant-edit.component.css'],
})
export class RestaurantEditComponent implements OnInit {
  private id: number;
  public updateRestaurantModel: UpdateRestaurantModel =
    new UpdateRestaurantModel();
  name = new FormControl('', Validators.required);
  addressId = new FormControl('', Validators.required);
  public addresses: AddressListModel[] = [];

  constructor(
    private restaurantService: RestaurantService,
    private addressService: AddressService,
    private router: Router,
    activeRoute: ActivatedRoute
  ) {
    this.id = Number.parseInt(activeRoute.snapshot.params['id']);
  }

  public ngOnInit(): void {
    if (this.id) {
      this.restaurantService
        .getRestaurant(this.id, true)
        .subscribe(
          (data: IRestaurantDetailModel) =>
            (this.updateRestaurantModel = new UpdateRestaurantModel(data))
        );
    }
    this.getAddressList();
  }

  public updateRestaurant(): void {
    this.restaurantService
      .updateRestaurant(this.updateRestaurantModel)
      .subscribe(() => this.router.navigateByUrl('restaurant'));
  }

  public getAddressList(): void {
    this.addressService
      .getAddressList()
      .subscribe(
        (data: IAddressListModel[]) =>
          (this.addresses = data.map((x) => new AddressListModel(x)))
      );
  }
}
