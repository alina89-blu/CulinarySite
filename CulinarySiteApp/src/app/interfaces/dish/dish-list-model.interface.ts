import { DishCategory } from 'src/app/enums/dish-category.enum';
import { DishImageModel } from 'src/app/viewmodels/image/dish-image/dish-image-model.class';

export interface IDishListModel {
  dishId: number;
  category: DishCategory;
  image: DishImageModel;
}
