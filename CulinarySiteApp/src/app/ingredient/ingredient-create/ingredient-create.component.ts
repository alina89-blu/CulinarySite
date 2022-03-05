import { Component, OnInit } from '@angular/core';
import { FormArray, FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { Unit } from 'src/app/enums/unit.enum';
import { IngredientService } from 'src/app/services/ingredient.service';
import { RecipeService } from 'src/app/services/recipe.service';
import { RecipeListModel } from 'src/app/viewmodels/recipe/recipe-list-model.class';
import { IRecipeListModel } from 'src/app/interfaces/recipe/recipe-list-model.interface';
import { CreateIngredientModel } from 'src/app/viewmodels/ingredient/create-ingredient-model.class';

@Component({
  selector: 'app-ingredient-create',
  templateUrl: './ingredient-create.component.html',
  styleUrls: ['./ingredient-create.component.css'],
})
export class IngredientCreateComponent implements OnInit {
  public createIngredientModel: CreateIngredientModel =
    new CreateIngredientModel();
  public units: Unit[] = [
    Unit.Грамм,
    Unit.Калории,
    Unit.Килограмм,
    Unit.Кусок,
    Unit.Литр,
    Unit.Миллилитр,
    Unit.Штука,
  ];
  myForm: FormGroup;
  public recipes: RecipeListModel[] = [];

  constructor(
    private ingredientService: IngredientService,
    private recipeService: RecipeService,
    private router: Router
  ) {
    this.myForm = new FormGroup({
      recipes: new FormArray([new FormControl('', Validators.required)]),
    });
  }

  public ngOnInit(): void {
    this.getRecipeList();
  }

  public createIngredient(): void {
    this.ingredientService
      .createIngredient(this.createIngredientModel)
      .subscribe(() => this.router.navigateByUrl('ingredient'));
  }

  public getFormsControls(): FormArray {
    return this.myForm.controls['recipes'] as FormArray;
  }

  /*  public addRecipe(): void {
    (<FormArray>this.myForm.controls['recipes']).push(
      new FormControl('', Validators.required)
    );
    this.createIngredientModel.recipes.push(new Recipe());
  }*/

  public getRecipeList(): void {
    this.recipeService
      .getRecipeList(false)
      .subscribe(
        (data: IRecipeListModel[]) =>
          (this.recipes = data.map((x) => new RecipeListModel(x)))
      );
  }

  submit() {
    console.log(this.myForm);
  }
}
