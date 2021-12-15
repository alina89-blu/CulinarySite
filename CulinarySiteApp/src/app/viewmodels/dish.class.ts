import { DishCategory } from '../enums/dish-category.enum';
import { IDish } from '../interfaces/dish.interface';
import { Recipe } from './recipe.class';
import { Image } from './image.class';

export class Dish {
  public id: number;
  public category: DishCategory;
  public recipes: Recipe[];
  public image: Image;

  constructor(public dish?: IDish) {
    if (dish) {
      this.id = dish.id;
      this.category = dish.category;
      this.recipes = dish.recipes;
      this.image = dish.image;
    }
  }
}
