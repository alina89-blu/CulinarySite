import { DishCategory } from 'src/app/enums/dish-category.enum';
import { IDishDetailModel } from 'src/app/interfaces/dish/dish-detail-model.interface';
import { DishRecipeModel } from '../recipe/dish-recipe.class';

export class DishDetailModel {
  public dishId: number;
  public category: DishCategory;
  public recipes: DishRecipeModel[];
  public imageUrl: string;

  constructor(public dishDetailModel?: IDishDetailModel) {
    if (dishDetailModel) {
      this.dishId = dishDetailModel.dishId;
      this.category = dishDetailModel.category;
      this.recipes = dishDetailModel.recipes;
      this.imageUrl = dishDetailModel.imageUrl;
    }
  }
}
