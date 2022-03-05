import { ICookingStageDetailModel } from 'src/app/interfaces/cooking-stage/cooking-stage-detail-model.interface';

export class CookingStageDetailModel {
  public cookingStageId: number;
  public recipeId: number;
  public content: string;

  constructor(public cookingStageDetailModel?: ICookingStageDetailModel) {
    if (cookingStageDetailModel) {
      this.cookingStageId = cookingStageDetailModel.cookingStageId;
      this.recipeId = cookingStageDetailModel.recipeId;
      this.content = cookingStageDetailModel.content;
    }
  }
}
