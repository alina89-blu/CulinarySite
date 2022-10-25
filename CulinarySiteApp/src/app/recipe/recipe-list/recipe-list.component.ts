import { Component, OnInit } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
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
  displayedColumns: string[] = [
    'id',
    'name',
    'servingsNumber',
    'cookingTime',
    'difficultyLevel',
    // 'content',
    'dishCategory',
    'authorName',
    'bookName',
    'actions',
  ];

  dataSource: MatTableDataSource<IRecipeListModel>;

  constructor(private recipeService: RecipeService) {}

  public ngOnInit(): void {
    this.getRecipeList();
  }

  /*  public getRecipeList(): void {
    this.recipeService
      .getRecipeList(true)
      .subscribe(
        (data: IRecipeListModel[]) =>
          (this.recipes = data.map((x) => new RecipeListModel(x)))
      );
  }*/

  public getRecipeList(): void {
    this.recipeService
      .getRecipeList(true)
      .subscribe((data: IRecipeListModel[]) => {
        this.recipes = data.map((x) => new RecipeListModel(x));
        this.dataSource = new MatTableDataSource<IRecipeListModel>(
          this.recipes
        );
      });
  }

  public deleteRecipe(id: number): void {
    this.recipeService.deleteRecipe(id).subscribe(() => this.getRecipeList());
  }
}
