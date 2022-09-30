import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { IRestaurantListModel } from 'src/app/interfaces/restaurant/restaurant-list-model.interface';
import { RestaurantService } from 'src/app/services/restaurant.service';
import { TelephoneService } from 'src/app/services/telephone.service';
import { RestaurantListModel } from 'src/app/viewmodels/restaurant/restaurant-list-model.class';
import { CreateTelephoneModel } from 'src/app/viewmodels/telephone/create-telephone-model.class';

@Component({
  selector: 'app-telephone-create',
  templateUrl: './telephone-create.component.html',
  styleUrls: ['./telephone-create.component.css'],
})
export class TelephoneCreateComponent implements OnInit {
  public createTelephoneModel: CreateTelephoneModel;
  public restaurants: RestaurantListModel[] = [];

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
      .getRestaurantList(false)
      .subscribe(
        (data: IRestaurantListModel[]) =>
          (this.restaurants = data.map((x) => new RestaurantListModel(x)))
      );
  }
}
