import { IRecipeModel } from 'src/app/interfaces/recipe/recipe-model.interface';
import { RecipeImageModel } from '../image/recipe-image/recipe-image-model.class';

export class RecipeModel {
  public recipeId: number;
  public name: string;
  public content: string;
  public image: RecipeImageModel;

  constructor(public recipeModel?: IRecipeModel) {
    if (recipeModel) {
      this.name = recipeModel.name;
      this.content = recipeModel.content;
      this.image = recipeModel.image;
    }
  }
}
