import { Unit } from 'src/app/enums/unit.enum';

export interface IRecipeIngredientDetailModel {
  recipeIngredientId: number;
  ingredientId: number;
  unit: Unit;
  quantity: number;
}
