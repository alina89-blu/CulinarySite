import { DishCategory } from 'src/app/enums/dish-category.enum';
import { IDishDetailModel } from 'src/app/interfaces/dish/dish-detail-model.interface';
import { RecipeDetailModel } from '../recipe/recipe-detail-model.class';
import { RecipeModel } from '../recipe/recipe-model.class';

export class DishDetailModel {
  public dishId: number;
  public category: DishCategory;
  //public recipes: RecipeModel[];
  public recipes: RecipeDetailModel[];

  constructor(public dishDetailModel?: IDishDetailModel) {
    if (dishDetailModel) {
      this.dishId = dishDetailModel.dishId;
      this.category = dishDetailModel.category;
      //this.recipes = dishDetailModel.recipes;
      this.recipes = dishDetailModel.recipes;
    }
  }
}
