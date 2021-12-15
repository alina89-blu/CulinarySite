import { IIngredient } from '../interfaces/ingredient.interface';
import { Unit } from '../enums/unit.enum';
import { Recipe } from './recipe.class';

export class Ingredient {
  public id: number;
  public name: string;
  public unit: Unit;
  public quantity: number;
  public recipes?: Recipe[];

  constructor(public ingredient?: IIngredient) {
    if (ingredient) {
      this.id = ingredient.id;
      this.name = ingredient.name;
      this.unit = ingredient.unit;
      this.quantity = ingredient.quantity;
      this.recipes = ingredient.recipes;
    }
  }
}
