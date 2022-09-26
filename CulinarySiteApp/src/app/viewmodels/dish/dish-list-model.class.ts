import { DishCategory } from 'src/app/enums/dish-category.enum';
import { IDishListModel } from 'src/app/interfaces/dish/dish-list-model.interface';
import { DishImageModel } from '../image/dish-image/dish-image-model.class';

export class DishListModel {
  public dishId: number;
  public category: DishCategory;
  public image: DishImageModel;

  constructor(public dishListModel?: IDishListModel) {
    if (dishListModel) {
      this.dishId = dishListModel.dishId;
      this.category = dishListModel.category;
      this.image = dishListModel.image;
    }
  }
}
