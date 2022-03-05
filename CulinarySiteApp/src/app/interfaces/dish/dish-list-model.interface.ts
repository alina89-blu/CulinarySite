import { DishCategory } from 'src/app/enums/dish-category.enum';

export interface IDishListModel {
  dishId: number;
  category: DishCategory;
}
