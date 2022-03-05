import { Unit } from 'src/app/enums/unit.enum';

export interface IRecipeIngredientListModel {
  recipeIngredientId: number;
  unit: Unit;
  quantity: number;
  ingredientName: string;
}
