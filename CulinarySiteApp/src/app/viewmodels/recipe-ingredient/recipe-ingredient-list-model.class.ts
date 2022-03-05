import { Unit } from 'src/app/enums/unit.enum';
import { IRecipeIngredientListModel } from 'src/app/interfaces/recipe-ingredient/recipe-ingredient-list-model.interface';

export class RecipeIngredientListModel {
  public recipeIngredientId: number;
  public unit: Unit;
  public quantity: number;
  public ingredientName: string;

  constructor(public recipeIngredientListModel?: IRecipeIngredientListModel) {
    if (recipeIngredientListModel) {
      this.recipeIngredientId = recipeIngredientListModel.recipeIngredientId;
      this.unit = recipeIngredientListModel.unit;
      this.quantity = recipeIngredientListModel.quantity;
      this.ingredientName = recipeIngredientListModel.ingredientName;
    }
  }
}
