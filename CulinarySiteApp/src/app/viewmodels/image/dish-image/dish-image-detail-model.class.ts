import { IDishImageDetailModel } from 'src/app/interfaces/image/dish-image/dish-image-detail-model.interface';

export class DishImageDetailModel {
  public dishImageId: number;
  public name: string;
  public url: string;
  public dishId: number;

  constructor(public dishImageDetailModel?: IDishImageDetailModel) {
    if (dishImageDetailModel) {
      this.dishImageId = dishImageDetailModel.dishImageId;
      this.name = dishImageDetailModel.name;
      this.url = dishImageDetailModel.url;
      this.dishId = dishImageDetailModel.dishId;
    }
  }
}
