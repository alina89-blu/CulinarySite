import { Component, OnInit } from '@angular/core';
import { IRestaurantListModel } from '../interfaces/restaurant/restaurant-list-model.interface';
import { RestaurantService } from '../services/restaurant.service';
import { RestaurantListModel } from '../viewmodels/restaurant/restaurant-list-model.class';

@Component({
  selector: 'app-restaurant-library',
  templateUrl: './restaurant-library.component.html',
  styleUrls: ['./restaurant-library.component.css'],
})
export class RestaurantLibraryComponent implements OnInit {
  public restaurants: RestaurantListModel[] = [];

  constructor(private restaurantService: RestaurantService) {}

  public ngOnInit(): void {
    this.getRestaurantDetailList();
  }

  public getRestaurantDetailList(): void {
    this.restaurantService
      .getRestaurantDetailList(true)
      .subscribe(
        (data: IRestaurantListModel[]) =>
          (this.restaurants = data.map((x) => new RestaurantListModel(x)))
      );
  }
}
