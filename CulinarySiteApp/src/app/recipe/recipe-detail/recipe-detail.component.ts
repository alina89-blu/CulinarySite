import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { IDishListModel } from 'src/app/interfaces/dish/dish-list-model.interface';
import { IRecipeDetailModel } from 'src/app/interfaces/recipe/recipe-detail-model.interface';
import { DishService } from 'src/app/services/dish.service';
import { RecipeService } from 'src/app/services/recipe.service';
import { DishListModel } from 'src/app/viewmodels/dish/dish-list-model.class';
import { RecipeDetailModel } from 'src/app/viewmodels/recipe/recipe-detail-model.class';

@Component({
  selector: 'app-recipe-detail',
  templateUrl: './recipe-detail.component.html',
  styleUrls: ['./recipe-detail.component.css'],
})
export class RecipeDetailComponent implements OnInit {
  id: number;
  recipeDetailModel: RecipeDetailModel = new RecipeDetailModel();
  dishes: DishListModel[] = [];

  constructor(
    private recipeService: RecipeService,
    activeRoute: ActivatedRoute,
    private http: HttpClient,
    private dishService: DishService
  ) {
    this.id = Number.parseInt(activeRoute.snapshot.params['id']);
  }

  public ngOnInit(): void {
    if (this.id) {
      this.recipeService
        .getRecipe(this.id, true)
        .subscribe(
          (data: IRecipeDetailModel) =>
            (this.recipeDetailModel = new RecipeDetailModel(data))
        );
    }
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
