import { Unit } from 'src/app/enums/unit.enum';
import { IRecipeIngredientDetailModel } from 'src/app/interfaces/recipe-ingredient/recipe-ingredient-detail-model.interface';

export class RecipeIngredientDetailModel {
  public recipeIngredientId: number;
  public ingredientId: number;
  public unit: Unit;
  public quantity: number;

  constructor(
    public recipeIngredientDetailModel?: IRecipeIngredientDetailModel
  ) {
    if (recipeIngredientDetailModel) {
      this.recipeIngredientId = recipeIngredientDetailModel.recipeIngredientId;
      this.ingredientId = recipeIngredientDetailModel.ingredientId;
      this.unit = recipeIngredientDetailModel.unit;
      this.quantity = recipeIngredientDetailModel.quantity;
    }
  }
}
