import { DishCategory } from 'src/app/enums/dish-category.enum';
import { IDishDetailModel } from 'src/app/interfaces/dish/dish-detail-model.interface';

export class DishDetailModel {
  public dishId: number;
  public category: DishCategory;

  constructor(public dishDetailModel?: IDishDetailModel) {
    if (dishDetailModel) {
      this.dishId = dishDetailModel.dishId;
      this.category = dishDetailModel.category;
    }
  }
}
