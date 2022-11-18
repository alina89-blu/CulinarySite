import { Component, OnInit } from '@angular/core';
import { IDishListModel } from '../interfaces/dish/dish-list-model.interface';
import { DishService } from '../services/dish.service';
import { DishListModel } from '../viewmodels/dish/dish-list-model.class';

@Component({
  selector: 'app-recipe-library',
  templateUrl: './recipe-library.component.html',
  styleUrls: ['./recipe-library.component.css'],
})
export class RecipeLibraryComponent implements OnInit {
  public dishes: DishListModel[] = [];

  constructor(private readonly dishService: DishService) {}

  public ngOnInit(): void {
    this.getDishDetailList();
  }

  public getDishDetailList(): void {
    this.dishService
      .getDishDetailList(true)
      .subscribe(
        (data: IDishListModel[]) =>
          (this.dishes = data.map((x) => new DishListModel(x)))
      );
  }
}
