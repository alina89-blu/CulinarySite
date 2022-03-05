import { Unit } from 'src/app/enums/unit.enum';
import { IRecipeIngredientDetailModel } from 'src/app/interfaces/recipe-ingredient/recipe-ingredient-detail-model.interface';
import { IUpdateRecipeIngredientModel } from 'src/app/interfaces/recipe-ingredient/update-recipe-ingredient-model.interface';

export class UpdateRecipeIngredientModel {
  public recipeIngredientId: number;
  public ingredientId: number;
  public unit: Unit;
  public quantity: number;

  constructor(
    public updateRecipeIngredientModel?:
      | IUpdateRecipeIngredientModel
      | IRecipeIngredientDetailModel
  ) {
    if (updateRecipeIngredientModel) {
      this.recipeIngredientId = updateRecipeIngredientModel.recipeIngredientId;
      this.ingredientId = updateRecipeIngredientModel.ingredientId;
      this.unit = updateRecipeIngredientModel.unit;
      this.quantity = updateRecipeIngredientModel.quantity;
    }
  }
}
