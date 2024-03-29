import { IRecipeModel } from 'src/app/interfaces/recipe/recipe-model.interface';

export class RecipeModel {
  public recipeId: number;
  public name: string;

  constructor(public recipeModel?: IRecipeModel) {
    if (recipeModel) {
      this.recipeId = recipeModel.recipeId;
      this.name = recipeModel.name;
    }
  }
}
