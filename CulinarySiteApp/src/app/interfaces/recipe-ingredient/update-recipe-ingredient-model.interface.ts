import { Unit } from 'src/app/enums/unit.enum';

export interface IUpdateRecipeIngredientModel {
  recipeIngredientId: number;
  ingredientId: number;
  unit: Unit;
  quantity: number;
}
