import { DishCategory } from 'src/app/enums/dish-category.enum';
import { IDishModel } from 'src/app/interfaces/dish/dish-model.interface';

export class DishModel {
  public dishId: number;
  public category: DishCategory;

  constructor(public dishModel?: IDishModel) {
    if (dishModel) {
      this.dishId = dishModel.dishId;
      this.category = dishModel.category;
    }
  }
}
