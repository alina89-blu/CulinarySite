import { DifficultyLevel } from 'src/app/enums/difficulty-level.enum';
import { CreateRecipeIngredientModel } from 'src/app/viewmodels/recipe-ingredient/create-recipe-ingredient-model.class';
import { RecipeIngredientModel } from 'src/app/viewmodels/recipe-ingredient/recipe-ingredient-model.class';
import { UpdateRecipeIngredientModel } from 'src/app/viewmodels/recipe-ingredient/update-recipe-ingredient-model.class';

export interface IUpdateRecipeModel {
  recipeId: number;
  name: string;
  servingsNumber: number;
  cookingTime: Date;
  difficultyLevel: DifficultyLevel;
  content: string;
  dishId: number;
  authorId: number;
  bookId: number;
  //recipeIngredients: RecipeIngredientModel[];
  recipeIngredients: UpdateRecipeIngredientModel[];
}
