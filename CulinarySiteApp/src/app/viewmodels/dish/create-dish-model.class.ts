import { DishCategory } from 'src/app/enums/dish-category.enum';
import { ICreateDishModel } from 'src/app/interfaces/dish/create-dish-model.interface';

export class CreateDishModel {
  public category: DishCategory;
  public imageUrl: string;

  constructor(public createDishModel?: ICreateDishModel) {
    if (createDishModel) {
      this.category = createDishModel.category;
      this.imageUrl = createDishModel.imageUrl;
    }
  }
}
