import { ICookingStageDetailModel } from 'src/app/interfaces/cooking-stage/cooking-stage-detail-model.interface';

export class CookingStageDetailModel {
  public cookingStageId: number;
  public content: string;
  public recipeId: number;
  public imageUrl: string;

  constructor(public cookingStageDetailModel?: ICookingStageDetailModel) {
    if (cookingStageDetailModel) {
      this.cookingStageId = cookingStageDetailModel.cookingStageId;
      this.content = cookingStageDetailModel.content;
      this.recipeId = cookingStageDetailModel.recipeId;
      this.imageUrl = cookingStageDetailModel.imageUrl;
    }
  }
}
