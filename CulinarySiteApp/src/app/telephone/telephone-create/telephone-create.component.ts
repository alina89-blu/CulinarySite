import { Component, OnInit } from '@angular/core';
import { FormControl, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { IRestaurantModel } from 'src/app/interfaces/restaurant/restaurant-model.interface';
import { RestaurantService } from 'src/app/services/restaurant.service';
import { TelephoneService } from 'src/app/services/telephone.service';
import { RestaurantModel } from 'src/app/viewmodels/restaurant/restaurant-model.class';
import { CreateTelephoneModel } from 'src/app/viewmodels/telephone/create-telephone-model.class';

@Component({
  selector: 'app-telephone-create',
  templateUrl: './telephone-create.component.html',
  styleUrls: ['./telephone-create.component.css'],
})
export class TelephoneCreateComponent implements OnInit {
  public createTelephoneModel: CreateTelephoneModel =
    new CreateTelephoneModel();
  number = new FormControl('', Validators.required);
  restaurantId = new FormControl('', Validators.required);

  public restaurants: RestaurantModel[] = [];

  constructor(
    private telephoneService: TelephoneService,
    private restaurantService: RestaurantService,
    private router: Router
  ) {}

  public ngOnInit(): void {
    this.getRestaurantList();
  }
  public createTelephone(): void {
    this.telephoneService
      .createTelephone(this.createTelephoneModel)
      .subscribe(() => this.router.navigateByUrl('telephone'));
  }

  public getRestaurantList(): void {
    this.restaurantService
      .getRestaurantList()
      .subscribe(
        (data: IRestaurantModel[]) =>
          (this.restaurants = data.map((x) => new RestaurantModel(x)))
      );
  }
}
