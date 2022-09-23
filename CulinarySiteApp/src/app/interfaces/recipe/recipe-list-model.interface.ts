import { DifficultyLevel } from 'src/app/enums/difficulty-level.enum';
import { CookingStageModel } from 'src/app/viewmodels/cooking-stage/cooking-stage-model.class';
import { IngredientModel } from 'src/app/viewmodels/ingredient/ingredient-model.class';
import { OrganicMatterModel } from 'src/app/viewmodels/organic-matter/organic-matter-model.class';
import { TagModel } from 'src/app/viewmodels/tag/tag-model.class';

export interface IRecipeListModel {
  recipeId: number;
  name: string;
  servingsNumber: number;
  cookingTime: Date;
  difficultyLevel: DifficultyLevel;
  content: string;
  dishCategory: string;
  authorName: string;
  bookName?: string;
  ingredients: IngredientModel[];
  organicMatters: OrganicMatterModel[];
  cookingStages: CookingStageModel[];
  tags: TagModel[];
}
