import { DishCategory } from 'src/app/enums/dish-category.enum';

export interface IUpdateDishModel {
  dishId: number;
  category: DishCategory;
}
