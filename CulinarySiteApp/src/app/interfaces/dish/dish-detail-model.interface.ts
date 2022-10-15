import { DishCategory } from 'src/app/enums/dish-category.enum';
import { RecipeDetailModel } from 'src/app/viewmodels/recipe/recipe-detail-model.class';
import { RecipeModel } from 'src/app/viewmodels/recipe/recipe-model.class';

export interface IDishDetailModel {
  dishId: number;
  category: DishCategory;
  //recipes: RecipeModel[];
  imageUrl: string;

  recipes: RecipeDetailModel[];
}
