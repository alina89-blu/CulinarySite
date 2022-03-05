import { DifficultyLevel } from 'src/app/enums/difficulty-level.enum';
import { RecipeIngredientModel } from 'src/app/viewmodels/recipe-ingredient/recipe-ingredient-model.class';

export interface IRecipeListModel {
  recipeId: number;
  name: string;
  servingsNumber: number;
  cookingTime: Date;
  difficultyLevel: DifficultyLevel;
  content: string;
  dishCategory: string;
  authorName: string;
  bookName: string;
  recipeIngredients: RecipeIngredientModel[];
}
