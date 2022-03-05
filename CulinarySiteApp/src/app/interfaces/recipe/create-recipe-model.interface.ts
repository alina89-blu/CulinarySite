import { DifficultyLevel } from 'src/app/enums/difficulty-level.enum';
import { CreateRecipeIngredientModel } from 'src/app/viewmodels/recipe-ingredient/create-recipe-ingredient-model.class';
import { RecipeIngredientModel } from 'src/app/viewmodels/recipe-ingredient/recipe-ingredient-model.class';
import { CreateRecipeOrganicMatterModel } from 'src/app/viewmodels/recipe-organic-matter/create-recipe-organic-matter-model.class';

export interface ICreateRecipeModel {
  name: string;
  servingsNumber: number;
  cookingTime: Date;
  difficultyLevel: DifficultyLevel;
  content: string;
  dishId: number;
  authorId: number;
  bookId: number;
  recipeIngredients: CreateRecipeIngredientModel[];
  recipeOrganicMatters: CreateRecipeOrganicMatterModel[];
}
