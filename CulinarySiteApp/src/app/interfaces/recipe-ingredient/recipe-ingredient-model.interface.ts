import { Unit } from 'src/app/enums/unit.enum';

export interface IRecipeIngredientModel {
  recipeIngredientId: number;
  ingredientId: number;
  unit: Unit;
  quantity: number;
}
