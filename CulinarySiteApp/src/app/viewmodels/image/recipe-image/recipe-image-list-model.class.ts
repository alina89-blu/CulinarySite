import { IRecipeImageListModel } from 'src/app/interfaces/image/recipe-image/recipe-image-list-model.interface';

export class RecipeImageListModel {
  public recipeImageId: number;
  public name: string;
  public url: string;
  public recipeName: string;

  constructor(public recipeImageListModel?: IRecipeImageListModel) {
    if (recipeImageListModel) {
      this.recipeImageId = recipeImageListModel.recipeImageId;
      this.name = recipeImageListModel.name;
      this.url = recipeImageListModel.url;
      this.recipeName = recipeImageListModel.recipeName;
    }
  }
}
