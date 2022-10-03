import { DishCategory } from 'src/app/enums/dish-category.enum';

export interface IDishModel {
  dishId: number;
  category: DishCategory;
}
