import { DifficultyLevel } from 'src/app/enums/difficulty-level.enum';
import { RecipeIngredientModel } from 'src/app/viewmodels/recipe-ingredient/recipe-ingredient-model.class';

export interface IRecipeDetailModel {
  recipeId: number;
  name: string;
  servingsNumber: number;
  cookingTime: Date;
  difficultyLevel: DifficultyLevel;
  content: string;
  dishId: number;
  authorId: number;
  bookId: number;
  recipeIngredients: RecipeIngredientModel[];
}
