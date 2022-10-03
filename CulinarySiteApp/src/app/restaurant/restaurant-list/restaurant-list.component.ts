import { Component, OnInit } from '@angular/core';
import { IRestaurantListModel } from 'src/app/interfaces/restaurant/restaurant-list-model.interface';
import { RestaurantService } from 'src/app/services/restaurant.service';
import { RestaurantListModel } from 'src/app/viewmodels/restaurant/restaurant-list-model.class';

@Component({
  selector: 'app-restaurant-list',
  templateUrl: './restaurant-list.component.html',
  styleUrls: ['./restaurant-list.component.css'],
})
export class RestaurantListComponent implements OnInit {
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

  public deleteRestaurant(id: number): void {
    this.restaurantService
      .deleteRestaurant(id)
      .subscribe(() => this.getRestaurantDetailList());
  }
}
