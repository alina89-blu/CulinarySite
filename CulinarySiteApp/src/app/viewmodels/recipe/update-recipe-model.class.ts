import { DifficultyLevel } from 'src/app/enums/difficulty-level.enum';
import { IRecipeDetailModel } from 'src/app/interfaces/recipe/recipe-detail-model.interface';
import { IUpdateRecipeModel } from 'src/app/interfaces/recipe/update-recipe-model.interface';
import { UpdateCookingStageModel } from '../cooking-stage/update-cooking-stage-model.class';
import { UpdateIngredientModel } from '../ingredient/update-ingredient-model.class';
import { UpdateOrganicMatterModel } from '../organic-matter/update-organic-matter-model.class';

export class UpdateRecipeModel {
  public recipeId: number;
  public name: string;
  public servingsNumber: number;
  public cookingTime: Date = new Date();
  public difficultyLevel: DifficultyLevel;
  public content: string;
  public dishId: number;
  public authorId: number;
  public bookId?: number;
  public ingredients: UpdateIngredientModel[];
  public organicMatters: UpdateOrganicMatterModel[];
  public cookingStages: UpdateCookingStageModel[];
  public imageUrl: string;

  constructor(
    public updateRecipeModel?: IUpdateRecipeModel | IRecipeDetailModel
  ) {
    if (updateRecipeModel) {
      this.recipeId = updateRecipeModel.recipeId;
      this.name = updateRecipeModel.name;
      this.servingsNumber = updateRecipeModel.servingsNumber;
      this.cookingTime = updateRecipeModel.cookingTime;
      this.difficultyLevel = updateRecipeModel.difficultyLevel;
      this.content = updateRecipeModel.content;
      this.dishId = updateRecipeModel.dishId;
      this.authorId = updateRecipeModel.authorId;
      this.bookId = updateRecipeModel.bookId;
      this.ingredients = updateRecipeModel.ingredients;
      this.organicMatters = updateRecipeModel.organicMatters;
      this.cookingStages = updateRecipeModel.cookingStages;
      this.imageUrl = updateRecipeModel.imageUrl;
    }
  }
}
