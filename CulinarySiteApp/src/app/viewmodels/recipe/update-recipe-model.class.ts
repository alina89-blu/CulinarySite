import { DifficultyLevel } from 'src/app/enums/difficulty-level.enum';
import { IRecipeDetailModel } from 'src/app/interfaces/recipe/recipe-detail-model.interface';
import { IUpdateRecipeModel } from 'src/app/interfaces/recipe/update-recipe-model.interface';
import { RecipeIngredientModel } from '../recipe-ingredient/recipe-ingredient-model.class';

export class UpdateRecipeModel {
  public recipeId: number;
  public name: string;
  public servingsNumber: number;
  public cookingTime: Date = new Date();
  public difficultyLevel: DifficultyLevel;
  public content: string;
  public dishId: number;
  public authorId: number;
  public bookId?: number;
  public recipeIngredients: RecipeIngredientModel[];

  constructor(
    public updateRecipeModel?: IUpdateRecipeModel | IRecipeDetailModel
  ) {
    if (updateRecipeModel) {
      this.recipeId = updateRecipeModel.recipeId;
      this.name = updateRecipeModel.name;
      this.servingsNumber = updateRecipeModel.servingsNumber;
      this.cookingTime = updateRecipeModel.cookingTime;
      this.difficultyLevel = updateRecipeModel.difficultyLevel;
      this.content = updateRecipeModel.content;
      this.dishId = updateRecipeModel.dishId;
      this.authorId = updateRecipeModel.authorId;
      this.bookId = updateRecipeModel.bookId;
      this.recipeIngredients = updateRecipeModel.recipeIngredients;
    }
  }
}
