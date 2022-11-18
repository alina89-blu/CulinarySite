import { Component, OnInit } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
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
  public displayedColumns: string[] = ['id', 'name', 'address', 'actions'];
  public dataSource: MatTableDataSource<IRestaurantListModel>;

  constructor(private readonly restaurantService: RestaurantService) {}

  public ngOnInit(): void {
    this.getRestaurantDetailList();
  }

  public getRestaurantDetailList(): void {
    this.restaurantService
      .getRestaurantDetailList(true)
      .subscribe((data: IRestaurantListModel[]) => {
        this.restaurants = data.map((x) => new RestaurantListModel(x));
        this.dataSource = new MatTableDataSource<IRestaurantListModel>(
          this.restaurants
        );
      });
  }

  public deleteRestaurant(id: number): void {
    this.restaurantService
      .deleteRestaurant(id)
      .subscribe(() => this.getRestaurantDetailList());
  }
}
