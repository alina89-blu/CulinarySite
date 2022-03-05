import { Unit } from 'src/app/enums/unit.enum';
import { IRecipeIngredientModel } from 'src/app/interfaces/recipe-ingredient/recipe-ingredient-model.interface';

export class RecipeIngredientModel {
  public recipeIngredientId: number;
  public ingredientId: number;
  public unit: Unit;
  public quantity: number;

  constructor(public recipeIngredientModel?: IRecipeIngredientModel) {
    if (recipeIngredientModel) {
      this.recipeIngredientId = recipeIngredientModel.recipeIngredientId;
      this.ingredientId = recipeIngredientModel.ingredientId;
      this.unit = recipeIngredientModel.unit;
      this.quantity = recipeIngredientModel.quantity;
    }
  }
}
