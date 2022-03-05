import { DifficultyLevel } from 'src/app/enums/difficulty-level.enum';
import { IRecipeDetailModel } from 'src/app/interfaces/recipe/recipe-detail-model.interface';
import { RecipeIngredientModel } from '../recipe-ingredient/recipe-ingredient-model.class';

export class RecipeDetailModel {
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

  constructor(public recipeDetailModel?: IRecipeDetailModel) {
    if (recipeDetailModel) {
      this.recipeId = recipeDetailModel.recipeId;
      this.name = recipeDetailModel.name;
      this.servingsNumber = recipeDetailModel.servingsNumber;
      this.cookingTime = recipeDetailModel.cookingTime;
      this.difficultyLevel = recipeDetailModel.difficultyLevel;
      this.content = recipeDetailModel.content;
      this.dishId = recipeDetailModel.dishId;
      this.authorId = recipeDetailModel.authorId;
      this.bookId = recipeDetailModel.bookId;
      this.recipeIngredients = recipeDetailModel.recipeIngredients;
    }
  }
}
