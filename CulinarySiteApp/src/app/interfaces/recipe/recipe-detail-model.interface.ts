import { DifficultyLevel } from 'src/app/enums/difficulty-level.enum';
import { CookingStageModel } from 'src/app/viewmodels/cooking-stage/cooking-stage-model.class';
import { IngredientModel } from 'src/app/viewmodels/ingredient/ingredient-model.class';
import { OrganicMatterModel } from 'src/app/viewmodels/organic-matter/organic-matter-model.class';

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
  ingredients: IngredientModel[];
  organicMatters: OrganicMatterModel[];
  cookingStages: CookingStageModel[];
  imageUrl: string;
}
