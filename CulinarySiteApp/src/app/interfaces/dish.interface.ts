import { DishCategory } from '../enums/dish-category.enum';
import { Recipe } from '../viewmodels/recipe.class';
import { Image } from '../viewmodels/image.class';

export interface IDish {
  id: number;
  category: DishCategory;
  recipes: Recipe[];
  image: Image;
}
