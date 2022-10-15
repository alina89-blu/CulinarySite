import { DishCategory } from 'src/app/enums/dish-category.enum';

export interface ICreateDishModel {
  category: DishCategory;
  imageUrl: string;
}
