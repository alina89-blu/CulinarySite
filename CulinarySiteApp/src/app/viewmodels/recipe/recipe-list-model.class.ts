import { DifficultyLevel } from 'src/app/enums/difficulty-level.enum';
import { IRecipeListModel } from 'src/app/interfaces/recipe/recipe-list-model.interface';
import { RecipeIngredientModel } from '../recipe-ingredient/recipe-ingredient-model.class';

export class RecipeListModel {
  public recipeId: number;
  public name: string;
  public servingsNumber: number;
  public cookingTime: Date = new Date();
  public difficultyLevel: DifficultyLevel;
  public content: string;
  public dishCategory: string;
  public authorName: string;
  public bookName?: string;
  public recipeIngredients: RecipeIngredientModel[];

  constructor(public recipeListModel?: IRecipeListModel) {
    if (recipeListModel) {
      this.recipeId = recipeListModel.recipeId;
      this.name = recipeListModel.name;
      this.servingsNumber = recipeListModel.servingsNumber;
      this.cookingTime = recipeListModel.cookingTime;
      this.difficultyLevel = recipeListModel.difficultyLevel;
      this.content = recipeListModel.content;
      this.dishCategory = recipeListModel.dishCategory;
      this.authorName = recipeListModel.authorName;
      this.bookName = recipeListModel.bookName;
      this.recipeIngredients = recipeListModel.recipeIngredients;
    }
  }
}
