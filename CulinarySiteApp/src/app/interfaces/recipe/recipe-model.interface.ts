import { RecipeImageModel } from 'src/app/viewmodels/image/recipe-image/recipe-image-model.class';

export interface IRecipeModel {
  recipeId: number;
  name: string;
  content: string;
  image: RecipeImageModel;
}
