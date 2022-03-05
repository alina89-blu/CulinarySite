import { Component, OnInit } from '@angular/core';
import { DishService } from 'src/app/services/dish.service';
import { DishListModel } from 'src/app/viewmodels/dish/dish-list-model.class';
import { IDishListModel } from 'src/app/interfaces/dish/dish-list-model.interface';

@Component({
  selector: 'app-dish-list',
  templateUrl: './dish-list.component.html',
  styleUrls: ['./dish-list.component.css'],
})
export class DishListComponent implements OnInit {
  public dishes: DishListModel[] = [];

  constructor(private dishService: DishService) {}

  public ngOnInit(): void {
    this.getDishList();
  }

  public getDishList(): void {
    this.dishService
      .getDishList(true)
      .subscribe(
        (data: IDishListModel[]) =>
          (this.dishes = data.map((x) => new DishListModel(x)))
      );
  }

  public deleteDish(id: number): void {
    this.dishService.deleteDish(id).subscribe(() => this.getDishList());
  }
}
