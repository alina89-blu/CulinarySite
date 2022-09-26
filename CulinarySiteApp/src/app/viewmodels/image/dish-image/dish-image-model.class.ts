import { IDishImageModel } from 'src/app/interfaces/image/dish-image/dish-image-model.interface';

export class DishImageModel {
  public dishImageId: number;
  public name: string;
  public url: string;

  constructor(public dishImageModel?: IDishImageModel) {
    if (dishImageModel) {
      this.dishImageId = dishImageModel.dishImageId;
      this.name = dishImageModel.name;
      this.url = dishImageModel.url;
    }
  }
}
