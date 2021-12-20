import { ICookingStage } from '../interfaces/cooking-stage.interface';
import { Recipe } from './recipe.class';
import { Image } from './image.class';

export class CookingStage {
  public id: number;
  public content: string;
  public recipeId: number;
  public recipe: Recipe;
  public images?: Image[];

  constructor(public cookingStage?: ICookingStage) {
    if (cookingStage) {
      this.id = cookingStage.id;
      this.content = cookingStage.content;
      this.recipeId = cookingStage.recipeId;
      this.recipe = cookingStage.recipe;
      this.images = cookingStage.images;
    }
  }
}
