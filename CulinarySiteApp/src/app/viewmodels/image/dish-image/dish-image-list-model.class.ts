import { IDishImageListModel } from 'src/app/interfaces/image/dish-image/dish-image-list-model.interface';

export class DishImageListModel {
  public dishImageId: number;
  public name: string;
  public url: string;
  public dishCategory: string;

  constructor(public dishImageListModel?: IDishImageListModel) {
    if (dishImageListModel) {
      this.dishImageId = dishImageListModel.dishImageId;
      this.name = dishImageListModel.name;
      this.url = dishImageListModel.url;
      this.dishCategory = dishImageListModel.dishCategory;
    }
  }
}
