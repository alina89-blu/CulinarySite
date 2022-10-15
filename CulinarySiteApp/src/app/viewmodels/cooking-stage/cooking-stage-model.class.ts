import { ICookingStageModel } from 'src/app/interfaces/cooking-stage/cooking-stage-model.interface';

export class CookingStageModel {
  public cookingStageId: number;
  public content: string;
  public recipeId: number;
  public imageUrl: string;

  constructor(public cookingStageModel?: ICookingStageModel) {
    if (cookingStageModel) {
      this.cookingStageId = cookingStageModel.cookingStageId;
      this.content = cookingStageModel.content;
      this.recipeId = cookingStageModel.recipeId;
      this.imageUrl = cookingStageModel.imageUrl;
    }
  }
}
