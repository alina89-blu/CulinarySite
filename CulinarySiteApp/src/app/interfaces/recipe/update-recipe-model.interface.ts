import { DifficultyLevel } from 'src/app/enums/difficulty-level.enum';
import { UpdateCookingStageModel } from 'src/app/viewmodels/cooking-stage/update-cooking-stage-model.class';
import { UpdateIngredientModel } from 'src/app/viewmodels/ingredient/update-ingredient-model.class';
import { UpdateOrganicMatterModel } from 'src/app/viewmodels/organic-matter/update-organic-matter-model.class';
import { UpdateTagModel } from 'src/app/viewmodels/tag/update-tag-model.class';

export interface IUpdateRecipeModel {
  recipeId: number;
  name: string;
  servingsNumber: number;
  cookingTime: Date;
  difficultyLevel: DifficultyLevel;
  content: string;
  dishId: number;
  authorId: number;
  bookId?: number;
  ingredients: UpdateIngredientModel[];
  organicMatters: UpdateOrganicMatterModel[];
  cookingStages: UpdateCookingStageModel[];
  tags: UpdateTagModel[];
}
