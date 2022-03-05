import { Unit } from 'src/app/enums/unit.enum';
import { ICreateRecipeIngredientModel } from 'src/app/interfaces/recipe-ingredient/create-recipe-ingredient-model.interface';
import { RecipeModel } from '../recipe/recipe-model.class';

export class CreateRecipeIngredientModel {
  public recipeIngredientId: number; //
  public ingredientId: number;
  public unit: Unit;
  public quantity: number;

  constructor(
    public createRecipeIngredientModel?: ICreateRecipeIngredientModel
  ) {
    if (createRecipeIngredientModel) {
      this.recipeIngredientId = createRecipeIngredientModel.recipeIngredientId;
      this.ingredientId = createRecipeIngredientModel.ingredientId;
      this.unit = createRecipeIngredientModel.unit;
      this.quantity = createRecipeIngredientModel.quantity;
    }
  }
}
