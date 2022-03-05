import { DishCategory } from 'src/app/enums/dish-category.enum';

export interface IDishDetailModel {
  dishId: number;
  category: DishCategory;
}
