import { IRecipeImageModel } from 'src/app/interfaces/image/recipe-image/recipe-image-model.interface';

export class RecipeImageModel {
  public recipeImageId: number;
  public name: string;
  public url: string;

  constructor(public recipeImageModel?: IRecipeImageModel) {
    if (recipeImageModel) {
      this.recipeImageId = recipeImageModel.recipeImageId;
      this.name = recipeImageModel.name;
      this.url = recipeImageModel.url;
    }
  }
}
