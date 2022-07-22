import { Unit } from 'src/app/enums/unit.enum';
import { IngredientDetailModel } from 'src/app/viewmodels/ingredient/ingredient-detail-model.class';

export interface IRecipeIngredientModel {
  recipeIngredientId: number;
  ingredientId: number;
  ingredient: IngredientDetailModel;
  unit: Unit;
  quantity: number;
}
