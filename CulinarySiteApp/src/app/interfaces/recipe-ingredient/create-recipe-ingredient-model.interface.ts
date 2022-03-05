import { Unit } from 'src/app/enums/unit.enum';
import { RecipeModel } from 'src/app/viewmodels/recipe/recipe-model.class';

export interface ICreateRecipeIngredientModel {
  recipeIngredientId: number; //
  ingredientId: number;
  unit: Unit;
  quantity: number;
}
