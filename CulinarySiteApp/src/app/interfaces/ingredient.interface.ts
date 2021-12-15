import { Unit } from '../enums/unit.enum';
import { Recipe } from '../viewmodels/recipe.class';

export interface IIngredient {
  id: number;
  name: string;
  unit: Unit;
  quantity: number;
  recipes: Recipe[];
}
