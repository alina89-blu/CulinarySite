import { Component, OnInit } from '@angular/core';
import { DifficultyLevel } from 'src/app/enums/difficulty-level.enum';
import { RecipeService } from 'src/app/services/recipe.service';
import { ActivatedRoute, Router } from '@angular/router';
import { DishService } from 'src/app/services/dish.service';
import { UpdateRecipeModel } from 'src/app/viewmodels/recipe/update-recipe-model.class';
import { IRecipeDetailModel } from 'src/app/interfaces/recipe/recipe-detail-model.interface';
import { DishListModel } from 'src/app/viewmodels/dish/dish-list-model.class';
import { IDishListModel } from 'src/app/interfaces/dish/dish-list-model.interface';

@Component({
  selector: 'app-recipe-edit',
  templateUrl: './recipe-edit.component.html',
  styleUrls: ['./recipe-edit.component.css'],
})
export class RecipeEditComponent implements OnInit {
  private id: number;
  public updateRecipeModel: UpdateRecipeModel = new UpdateRecipeModel();
  difficultyLevels: DifficultyLevel[] = [
    DifficultyLevel.Лёгкий,
    DifficultyLevel['Очень Лёгкий'],
    DifficultyLevel.Средний,
    DifficultyLevel['Выше cреднего'],
    DifficultyLevel.Сложный,
  ];
  public dishes: DishListModel[] = [];

  constructor(
    private recipeService: RecipeService,
    private dishService: DishService,
    private router: Router,
    activeRoute: ActivatedRoute
  ) {
    this.id = Number.parseInt(activeRoute.snapshot.params['id']);
  }

  public ngOnInit(): void {
    if (this.id) {
      this.recipeService
        .getRecipe(this.id, true)
        .subscribe(
          (data: IRecipeDetailModel) =>
            (this.updateRecipeModel = new UpdateRecipeModel(data))
        );
    }
    this.getDishList();
  }

  public updateRecipe(): void {
    this.recipeService
      .updateRecipe(this.updateRecipeModel)
      .subscribe(() => this.router.navigateByUrl('recipe'));
  }

  public getDishList(): void {
    this.dishService
      .getDishList(false)
      .subscribe(
        (data: IDishListModel[]) =>
          (this.dishes = data.map((x) => new DishListModel(x)))
      );
  }
}
