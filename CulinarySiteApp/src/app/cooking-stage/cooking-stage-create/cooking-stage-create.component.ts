import { Component, OnInit } from '@angular/core';
import { FormControl, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { IRecipeModel } from 'src/app/interfaces/recipe/recipe-model.interface';
import { CookingStageService } from 'src/app/services/cooking-stage.service';
import { RecipeService } from 'src/app/services/recipe.service';
import { CreateCookingStageModel } from 'src/app/viewmodels/cooking-stage/create-cooking-stage-model.class';
import { RecipeModel } from 'src/app/viewmodels/recipe/recipe-model.class';

@Component({
  selector: 'app-cooking-stage-create',
  templateUrl: './cooking-stage-create.component.html',
  styleUrls: ['./cooking-stage-create.component.css'],
})
export class CookingStageCreateComponent implements OnInit {
  public createCookingStageModel: CreateCookingStageModel =
    new CreateCookingStageModel();
  public recipes: RecipeModel[] = [];

  content = new FormControl('', Validators.required);
  imageUrl = new FormControl('', Validators.required);
  recipeId = new FormControl('', Validators.required);

  constructor(
    private cookingStageService: CookingStageService,
    private recipeService: RecipeService,
    private router: Router
  ) {}

  public ngOnInit(): void {
    this.getRecipeList();
  }

  public createCookingStage(): void {
    this.cookingStageService
      .createCookingStage(this.createCookingStageModel)
      .subscribe(() => this.router.navigateByUrl('cookingStage'));
  }

  public getRecipeList(): void {
    this.recipeService
      .getRecipeList()
      .subscribe(
        (data: IRecipeModel[]) =>
          (this.recipes = data.map((x) => new RecipeModel(x)))
      );
  }
}
