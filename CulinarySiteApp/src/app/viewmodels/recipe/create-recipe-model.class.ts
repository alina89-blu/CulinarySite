import { DifficultyLevel } from 'src/app/enums/difficulty-level.enum';
import { ICreateRecipeModel } from 'src/app/interfaces/recipe/create-recipe-model.interface';
import { CreateCookingStageModel } from '../cooking-stage/create-cooking-stage-model.class';
import { CreateIngredientModel } from '../ingredient/create-ingredient-model.class';
import { CreateOrganicMatterModel } from '../organic-matter/create-organic-matter-model.class';
import { CreateTagModel } from '../tag/create-tag-model.class';

export class CreateRecipeModel {
  public name: string;
  public servingsNumber: number;
  public cookingTime: Date = new Date();
  public difficultyLevel: DifficultyLevel;
  public content: string;
  public dishId: number;
  public authorId: number;
  public bookId?: number;
  public ingredients: CreateIngredientModel[];
  public organicMatters: CreateOrganicMatterModel[];
  public cookingStages: CreateCookingStageModel[];
  public tags: CreateTagModel[];
  public imageUrl: string;

  constructor(public createRecipeModel?: ICreateRecipeModel) {
    if (createRecipeModel) {
      this.name = createRecipeModel.name;
      this.servingsNumber = createRecipeModel.servingsNumber;
      this.cookingTime = createRecipeModel.cookingTime;
      this.difficultyLevel = createRecipeModel.difficultyLevel;
      this.content = createRecipeModel.content;
      this.dishId = createRecipeModel.dishId;
      this.authorId = createRecipeModel.authorId;
      this.bookId = createRecipeModel.bookId;
      this.ingredients = createRecipeModel.ingredients;
      this.organicMatters = createRecipeModel.organicMatters;
      this.cookingStages = createRecipeModel.cookingStages;
      this.tags = createRecipeModel.tags;
      this.imageUrl = createRecipeModel.imageUrl;
    }
  }
}
