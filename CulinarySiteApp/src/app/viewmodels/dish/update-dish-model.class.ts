import { DishCategory } from 'src/app/enums/dish-category.enum';
import { IDishDetailModel } from 'src/app/interfaces/dish/dish-detail-model.interface';
import { IUpdateDishModel } from 'src/app/interfaces/dish/update-dish-model.interface';

export class UpdateDishModel {
  public dishId: number;
  public category: DishCategory;
  public imageUrl: string;

  constructor(public updateDishModel?: IUpdateDishModel | IDishDetailModel) {
    if (updateDishModel) {
      this.dishId = updateDishModel.dishId;
      this.category = updateDishModel.category;
      this.imageUrl = updateDishModel.imageUrl;
    }
  }
}
