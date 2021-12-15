import { Recipe } from '../viewmodels/recipe.class';
import { Image } from '../viewmodels/image.class';

export interface ICookingStage {
  id: number;
  content: string;
  recipeId: number;
  recipe: Recipe;
  images: Image[];
}
