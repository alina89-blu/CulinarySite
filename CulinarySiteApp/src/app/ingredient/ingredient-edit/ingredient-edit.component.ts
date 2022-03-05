import { Component, OnInit } from '@angular/core';
import { FormArray, FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Unit } from 'src/app/enums/unit.enum';
import { IIngredientDetailModel } from 'src/app/interfaces/ingredient/ingredient-detail-model.interface';
import { IRecipeListModel } from 'src/app/interfaces/recipe/recipe-list-model.interface';
import { IngredientService } from 'src/app/services/ingredient.service';
import { RecipeService } from 'src/app/services/recipe.service';
import { UpdateIngredientModel } from 'src/app/viewmodels/ingredient/update-ingredient-model.class';
import { RecipeListModel } from 'src/app/viewmodels/recipe/recipe-list-model.class';

@Component({
  selector: 'app-ingredient-edit',
  templateUrl: './ingredient-edit.component.html',
  styleUrls: ['./ingredient-edit.component.css'],
})
export class IngredientEditComponent implements OnInit {
  private id: number;
  public updateIngredientModel: UpdateIngredientModel =
    new UpdateIngredientModel();
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
  public recipesMas: RecipeListModel[] = [];

  constructor(
    private activeRoute: ActivatedRoute,
    private ingredientService: IngredientService,
    private recipeService: RecipeService,
    private router: Router
  ) {
    this.id = Number.parseInt(this.activeRoute.snapshot.params['id']);
    this.myForm = new FormGroup({
      recipes: new FormArray([new FormControl('', Validators.required)]),
    });
  }

  public ngOnInit(): void {
    if (this.id) {
      this.ingredientService
        .getIngredient(this.id, true)
        .subscribe(
          (data: IIngredientDetailModel) =>
            (this.updateIngredientModel = new UpdateIngredientModel(data))
        );
    }
    this.getRecipeList();
  }

  public updateIngredient(): void {
    this.ingredientService
      .updateIngredient(this.updateIngredientModel)
      .subscribe(() => this.router.navigateByUrl('ingredient'));
  }

  public getFormsControls(): FormArray {
    return this.myForm.controls['recipes'] as FormArray;
  }

  public addRecipe(): void {
    (<FormArray>this.myForm.controls['recipes']).push(
      new FormControl('', Validators.required)
    );
  }

  public getRecipeList(): void {
    this.recipeService
      .getRecipeList(false)
      .subscribe(
        (data: IRecipeListModel[]) =>
          (this.recipesMas = data.map((x) => new RecipeListModel(x)))
      );
  }
}
