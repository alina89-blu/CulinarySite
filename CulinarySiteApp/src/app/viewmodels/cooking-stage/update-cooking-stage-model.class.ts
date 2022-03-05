import { ICookingStageDetailModel } from 'src/app/interfaces/cooking-stage/cooking-stage-detail-model.interface';
import { IUpdateCookingStageModel } from 'src/app/interfaces/cooking-stage/update-cooking-stage-model.interface';

export class UpdateCookingStageModel {
  public cookingStageId: number;
  public content: string;
  public recipeId: number;

  constructor(
    public updateCookingStageModel?:
      | IUpdateCookingStageModel
      | ICookingStageDetailModel
  ) {
    if (updateCookingStageModel) {
      this.cookingStageId = updateCookingStageModel.cookingStageId;
      this.content = updateCookingStageModel.content;
      this.recipeId = updateCookingStageModel.recipeId;
    }
  }
}
