import { IRecipeImageDetailModel } from 'src/app/interfaces/image/recipe-image/recipe-image-detail-model.interface';
import { IUpdateRecipeImageModel } from 'src/app/interfaces/image/recipe-image/update-recipe-image-model.interface';

export class UpdateRecipeImageModel {
  public recipeImageId: number;
  public name: string;
  public url: string;
  public recipeId: number;

  constructor(
    public updateRecipeImageModel?:
      | IUpdateRecipeImageModel
      | IRecipeImageDetailModel
  ) {
    if (updateRecipeImageModel) {
      this.recipeImageId = updateRecipeImageModel.recipeImageId;
      this.name = updateRecipeImageModel.name;
      this.url = updateRecipeImageModel.url;
      this.recipeId = updateRecipeImageModel.recipeId;
    }
  }
}
