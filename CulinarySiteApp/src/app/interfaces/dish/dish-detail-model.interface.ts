import { DishCategory } from 'src/app/enums/dish-category.enum';
import { DishRecipeModel } from 'src/app/viewmodels/recipe/dish-recipe.class';

export interface IDishDetailModel {
  dishId: number;
  category: DishCategory;
  imageUrl: string;
  recipes: DishRecipeModel[];
}
