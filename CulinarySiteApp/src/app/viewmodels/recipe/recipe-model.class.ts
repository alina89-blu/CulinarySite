import { IRecipeModel } from 'src/app/interfaces/recipe/recipe-model.interface';

export class RecipeModel {
  public name: string;

  constructor(public recipeModel?: IRecipeModel) {
    if (recipeModel) {
      this.name = recipeModel.name;
    }
  }
}
