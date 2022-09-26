import { ICreateRecipeImageModel } from 'src/app/interfaces/image/recipe-image/create-recipe-image-model.interface';

export class CreateRecipeImageModel {
  public name: string;
  public url: string;
  public recipeId: number;
  constructor(public createRecipeImageModel?: ICreateRecipeImageModel) {
    if (createRecipeImageModel) {
      this.name = createRecipeImageModel.name;
      this.url = createRecipeImageModel.url;
      this.recipeId = createRecipeImageModel.recipeId;
    }
  }
}
