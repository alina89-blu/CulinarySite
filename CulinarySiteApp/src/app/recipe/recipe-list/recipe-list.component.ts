import { Component, OnInit } from '@angular/core';
import { IRecipeListModel } from 'src/app/interfaces/recipe/recipe-list-model.interface';
import { RecipeService } from 'src/app/services/recipe.service';
import { RecipeListModel } from 'src/app/viewmodels/recipe/recipe-list-model.class';

@Component({
  selector: 'app-recipe-list',
  templateUrl: './recipe-list.component.html',
  styleUrls: ['./recipe-list.component.css'],
})
export class RecipeListComponent implements OnInit {
  public recipes: RecipeListModel[] = [];

  constructor(private recipeService: RecipeService) {}

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
}
