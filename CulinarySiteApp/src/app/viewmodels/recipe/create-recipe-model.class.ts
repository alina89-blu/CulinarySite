import { DifficultyLevel } from 'src/app/enums/difficulty-level.enum';
import { ICreateRecipeModel } from 'src/app/interfaces/recipe/create-recipe-model.interface';
import { CreateRecipeIngredientModel } from '../recipe-ingredient/create-recipe-ingredient-model.class';
import { CreateRecipeOrganicMatterModel } from '../recipe-organic-matter/create-recipe-organic-matter-model.class';

export class CreateRecipeModel {
  public name: string;
  public servingsNumber: number;
  public cookingTime: Date = new Date();
  public difficultyLevel: DifficultyLevel;
  public content: string;
  public dishId: number;
  public authorId: number;
  public bookId?: number;
  public recipeIngredients: CreateRecipeIngredientModel[];
  public recipeOrganicMatters: CreateRecipeOrganicMatterModel[];

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
      this.recipeIngredients = createRecipeModel.recipeIngredients;
      this.recipeOrganicMatters = createRecipeModel.recipeOrganicMatters;
    }
  }
}
