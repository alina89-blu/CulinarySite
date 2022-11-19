import { DifficultyLevel } from 'src/app/enums/difficulty-level.enum';
import { CreateCookingStageModel } from 'src/app/viewmodels/cooking-stage/create-cooking-stage-model.class';
import { CreateIngredientModel } from 'src/app/viewmodels/ingredient/create-ingredient-model.class';
import { CreateOrganicMatterModel } from 'src/app/viewmodels/organic-matter/create-organic-matter-model.class';

export interface ICreateRecipeModel {
  name: string;
  servingsNumber: number;
  cookingTime: Date;
  difficultyLevel: DifficultyLevel;
  content: string;
  dishId: number;
  authorId: number;
  bookId?: number;
  ingredients: CreateIngredientModel[];
  organicMatters: CreateOrganicMatterModel[];
  cookingStages: CreateCookingStageModel[];
  imageUrl: string;
}
