import { DifficultyLevel } from 'src/app/enums/difficulty-level.enum';
import { IRecipeDetailModel } from 'src/app/interfaces/recipe/recipe-detail-model.interface';
import { CookingStageModel } from '../cooking-stage/cooking-stage-model.class';
import { RecipeImageModel } from '../image/recipe-image/recipe-image-model.class';
import { IngredientModel } from '../ingredient/ingredient-model.class';
import { OrganicMatterModel } from '../organic-matter/organic-matter-model.class';
import { TagModel } from '../tag/tag-model.class';

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
  public ingredients: IngredientModel[];
  public organicMatters: OrganicMatterModel[];
  public cookingStages: CookingStageModel[];
  public tags: TagModel[];
  public image: RecipeImageModel;

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
      this.ingredients = recipeDetailModel.ingredients;
      this.organicMatters = recipeDetailModel.organicMatters;
      this.cookingStages = recipeDetailModel.cookingStages;
      this.tags = recipeDetailModel.tags;
      this.image = recipeDetailModel.image;
    }
  }
}
