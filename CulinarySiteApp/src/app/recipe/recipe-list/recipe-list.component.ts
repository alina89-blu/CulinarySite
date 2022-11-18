import { Component, OnInit } from '@angular/core';
import { PageEvent } from '@angular/material/paginator';
import { Sort } from '@angular/material/sort';
import { IRecipeListModel } from 'src/app/interfaces/recipe/recipe-list-model.interface';
import { RecipeService } from 'src/app/services/recipe.service';

@Component({
  selector: 'app-recipe-list',
  templateUrl: './recipe-list.component.html',
  styleUrls: ['./recipe-list.component.css'],
})
export class RecipeListComponent implements OnInit {
  public totalRows: number = 0;
  public pageSize: number = 5;
  public activeColumn: string;
  public filterValue: string;
  public isAscending: boolean = true;
  public currentPage: number = 1;
  public pageSizeOptions: number[] = [3, 5, 10, 25];
  public dataSource: IRecipeListModel[];
  public displayedColumns: string[] = [
    'id',
    'name',
    'servingsNumber',
    'cookingTime',
    'difficultyLevel',
    'dishCategory',
    'authorName',
    'bookName',
    'actions',
  ];

  constructor(private readonly recipeService: RecipeService) {}

  public ngOnInit(): void {
    this.loadRecipes();
  }

  public loadRecipes(): void {
    this.recipeService
      .getPagedRecipes(
        this.currentPage,
        this.pageSize,
        this.isAscending,
        this.activeColumn,
        this.filterValue
      )
      .subscribe((result) => {
        this.dataSource = result.items;
        this.totalRows = result.totalCount;
      });
  }

  public pageChanged(event: PageEvent): void {
    this.pageSize = event.pageSize;
    this.currentPage = event.pageIndex + 1;

    this.loadRecipes();
  }

  public deleteRecipe(id: number): void {
    this.recipeService.deleteRecipe(id).subscribe(() => {
      this.currentPage = 1;

      this.loadRecipes();
    });
  }

  public filterData(): void {
    this.currentPage = 1;

    this.loadRecipes();
  }

  public sortData(sort: Sort): void {
    this.isAscending = sort.direction === 'asc';
    this.activeColumn = sort.active;

    this.loadRecipes();
  }
}
