import { ICreateDishImageModel } from 'src/app/interfaces/image/dish-image/create-dish-image-model.interface';

export class CreateDishImageModel {
  public name: string;
  public url: string;
  public dishId: number;
  constructor(public createDishImageModel?: ICreateDishImageModel) {
    if (createDishImageModel) {
      this.name = createDishImageModel.name;
      this.url = createDishImageModel.url;
      this.dishId = createDishImageModel.dishId;
    }
  }
}
