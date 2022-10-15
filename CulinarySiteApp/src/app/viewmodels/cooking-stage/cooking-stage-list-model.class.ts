import { ICookingStageListModel } from 'src/app/interfaces/cooking-stage/cooking-stage-list-model.interface';

export class CookingStageListModel {
  public cookingStageId: number;
  public content: string;
  public recipeName: string;
  public imageUrl: string;

  constructor(public cookingStageListModel?: ICookingStageListModel) {
    if (cookingStageListModel) {
      this.cookingStageId = cookingStageListModel.cookingStageId;
      this.content = cookingStageListModel.content;
      this.recipeName = cookingStageListModel.recipeName;
      this.imageUrl = cookingStageListModel.imageUrl;
    }
  }
}
