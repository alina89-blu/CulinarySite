import { Component, OnInit } from '@angular/core';
import { IIngredientListModel } from 'src/app/interfaces/ingredient/ingredient-list-model.interface';
import { IngredientService } from 'src/app/services/ingredient.service';
import { IngredientListModel } from 'src/app/viewmodels/ingredient/ingredient-list-model.class';

@Component({
  selector: 'app-ingredient-list',
  templateUrl: './ingredient-list.component.html',
  styleUrls: ['./ingredient-list.component.css'],
})
export class IngredientListComponent implements OnInit {
  public ingredients: IngredientListModel[] = [];

  constructor(private ingredientService: IngredientService) {}

  public ngOnInit(): void {
    this.getIngredientList();
  }

  public getIngredientList(): void {
    this.ingredientService
      .getIngredientList(true)
      .subscribe(
        (data: IIngredientListModel[]) =>
          (this.ingredients = data.map((x) => new IngredientListModel(x)))
      );
  }

  public deleteIngredient(id: number): void {
    this.ingredientService
      .deleteIngredient(id)
      .subscribe(() => this.getIngredientList());
  }
}
