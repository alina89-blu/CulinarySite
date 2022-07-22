import { Unit } from 'src/app/enums/unit.enum';
import { IRecipeIngredientModel } from 'src/app/interfaces/recipe-ingredient/recipe-ingredient-model.interface';
import { IngredientDetailModel } from '../ingredient/ingredient-detail-model.class';

export class RecipeIngredientModel {
  public recipeIngredientId: number;
  public ingredientId: number;
  public ingredient: IngredientDetailModel;
  public ingredientName: string;
  public unit: Unit;
  public quantity: number;

  constructor(public recipeIngredientModel?: IRecipeIngredientModel) {
    if (recipeIngredientModel) {
      this.recipeIngredientId = recipeIngredientModel.recipeIngredientId;
      this.ingredientId = recipeIngredientModel.ingredientId;
      this.ingredient = recipeIngredientModel.ingredient;
      this.unit = recipeIngredientModel.unit;
      this.quantity = recipeIngredientModel.quantity;
    }
  }
}
