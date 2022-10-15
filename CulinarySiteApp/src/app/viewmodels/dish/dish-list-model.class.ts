import { DishCategory } from 'src/app/enums/dish-category.enum';
import { IDishListModel } from 'src/app/interfaces/dish/dish-list-model.interface';

export class DishListModel {
  public dishId: number;
  public category: DishCategory;
  public imageUrl: string;

  constructor(public dishListModel?: IDishListModel) {
    if (dishListModel) {
      this.dishId = dishListModel.dishId;
      this.category = dishListModel.category;
      this.imageUrl = dishListModel.imageUrl;
    }
  }
}
