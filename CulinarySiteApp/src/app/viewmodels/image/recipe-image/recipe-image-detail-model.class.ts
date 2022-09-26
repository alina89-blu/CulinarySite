import { IRecipeImageDetailModel } from 'src/app/interfaces/image/recipe-image/recipe-image-detail-model.interface';

export class RecipeImageDetailModel {
  public recipeImageId: number;
  public name: string;
  public url: string;
  public recipeId: number;

  constructor(public recipeImageDetailModel?: IRecipeImageDetailModel) {
    if (recipeImageDetailModel) {
      this.recipeImageId = recipeImageDetailModel.recipeImageId;
      this.name = recipeImageDetailModel.name;
      this.url = recipeImageDetailModel.url;
      this.recipeId = recipeImageDetailModel.recipeId;
    }
  }
}
