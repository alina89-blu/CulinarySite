import { ICookingStageModel } from 'src/app/interfaces/cooking-stage/cooking-stage-model.interface';

export class CookingStageModel {
  public cookingStageId: number;
  public content: string;
  public recipeId: number;

  constructor(public cookingStageModel?: ICookingStageModel) {
    if (cookingStageModel) {
      this.cookingStageId = cookingStageModel.cookingStageId;
      this.content = cookingStageModel.content;
      this.recipeId = cookingStageModel.recipeId;
    }
  }
}
