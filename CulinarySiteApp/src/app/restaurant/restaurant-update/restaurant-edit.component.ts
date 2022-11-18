import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
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
  public addresses: AddressListModel[] = [];
  public restaurantForm: FormGroup;

  constructor(
    private readonly restaurantService: RestaurantService,
    private readonly addressService: AddressService,
    private readonly router: Router,
    private readonly fb: FormBuilder,
    activeRoute: ActivatedRoute
  ) {
    this.id = Number.parseInt(activeRoute.snapshot.params['id']);
  }

  public ngOnInit(): void {
    if (this.id) {
      this.restaurantService
        .getRestaurant(this.id, false)
        .subscribe(
          (data: IRestaurantDetailModel) =>
            (this.updateRestaurantModel = new UpdateRestaurantModel(data))
        );
    }

    this.getAddressList();

    this.restaurantForm = this.fb.group({
      name: ['', Validators.required],
      addressId: ['', Validators.required],
    });
  }

  public getAddressList(): void {
    this.addressService
      .getAddressList()
      .subscribe(
        (data: IAddressListModel[]) =>
          (this.addresses = data.map((x) => new AddressListModel(x)))
      );
  }

  public updateRestaurant(): void {
    this.restaurantService
      .updateRestaurant(this.updateRestaurantModel)
      .subscribe(() => this.router.navigateByUrl('restaurant'));
  }
}
