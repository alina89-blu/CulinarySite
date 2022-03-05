import { IDishImageDetailModel } from 'src/app/interfaces/image/dish-image/dish-image-detail-model.interface';
import { IUpdateDishImageModel } from 'src/app/interfaces/image/dish-image/update-dish-image-model.interface';

export class UpdateDishImageModel {
  public dishImageId: number;
  public name: string;
  public url: string;
  public dishId: number;

  constructor(
    public updateDishImageModel?: IUpdateDishImageModel | IDishImageDetailModel
  ) {
    if (updateDishImageModel) {
      this.dishImageId = updateDishImageModel.dishImageId;
      this.name = updateDishImageModel.name;
      this.url = updateDishImageModel.url;
      this.dishId = updateDishImageModel.dishId;
    }
  }
}
