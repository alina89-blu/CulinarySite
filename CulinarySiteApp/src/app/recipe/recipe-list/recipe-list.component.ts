import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Unit } from 'src/app/enums/unit.enum';
import { IIngredientListModel } from 'src/app/interfaces/ingredient/ingredient-list-model.interface';
import { IRecipeListModel } from 'src/app/interfaces/recipe/recipe-list-model.interface';
import { IngredientService } from 'src/app/services/ingredient.service';
import { RecipeIngredientService } from 'src/app/services/recipe-ingredient.service';
import { RecipeService } from 'src/app/services/recipe.service';
import { IngredientListModel } from 'src/app/viewmodels/ingredient/ingredient-list-model.class';
import { CreateRecipeIngredientModel } from 'src/app/viewmodels/recipe-ingredient/create-recipe-ingredient-model.class';
import { RecipeListModel } from 'src/app/viewmodels/recipe/recipe-list-model.class';

@Component({
  selector: 'app-recipe-list',
  templateUrl: './recipe-list.component.html',
  styleUrls: ['./recipe-list.component.css'],
})
export class RecipeListComponent implements OnInit {
  public recipes: RecipeListModel[] = [];
  hidded: boolean = false;
  public createRecipeIngredientModel: CreateRecipeIngredientModel =
    new CreateRecipeIngredientModel();
  public ingredients: IngredientListModel[] = [];
  public units: Unit[] = [
    Unit.Грамм,
    Unit.Калории,
    Unit.Килограмм,
    Unit.Кусок,
    Unit.Литр,
    Unit.Миллилитр,
    Unit.Штука,
  ];
  constructor(
    private recipeService: RecipeService,
    private recipeIngredientService: RecipeIngredientService,
    private router: Router,
    private ingredientService: IngredientService
  ) {}

  public ngOnInit(): void {
    this.getRecipeList();
  }

  public getRecipeList(): void {
    this.recipeService
      .getRecipeList(true)
      .subscribe(
        (data: IRecipeListModel[]) =>
          (this.recipes = data.map((x) => new RecipeListModel(x)))
      );
  }

  public deleteRecipe(id: number): void {
    this.recipeService.deleteRecipe(id).subscribe(() => this.getRecipeList());
  }

  public add() {
    this.hidded = !this.hidded;
  }

  public createRecipeIngredient(): void {
    this.recipeIngredientService
      .createRecipeIngredient(this.createRecipeIngredientModel)
      .subscribe(() => this.router.navigateByUrl('recipe'));

    //.subscribe(() => this.router.navigateByUrl('recipe'));
  }

  public getIngredientList(): void {
    this.ingredientService
      .getIngredientList(true)
      .subscribe(
        (data: IIngredientListModel[]) =>
          (this.ingredients = data.map((x) => new IngredientListModel(x)))
      );
  }
}
