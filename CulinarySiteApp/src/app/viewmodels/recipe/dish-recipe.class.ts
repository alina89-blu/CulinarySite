import { IDishRecipeModel } from 'src/app/interfaces/recipe/dish-recipe.interface';

export class DishRecipeModel {
  public recipeId: number;
  public name: string;
  public content: string;
  public imageUrl: string;

  constructor(public dishRecipeModel?: IDishRecipeModel) {
    if (dishRecipeModel) {
      this.recipeId = dishRecipeModel.recipeId;
      this.name = dishRecipeModel.name;
      this.content = dishRecipeModel.content;
      this.imageUrl = dishRecipeModel.imageUrl;
    }
  }
}
