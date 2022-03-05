import { ICreateCookingStageModel } from 'src/app/interfaces/cooking-stage/create-cooking-stage-model.interface';

export class CreateCookingStageModel {
  public content: string;
  public recipeId: number;

  constructor(public createCookingStageModel?: ICreateCookingStageModel) {
    if (createCookingStageModel) {
      this.content = createCookingStageModel.content;
      this.recipeId = createCookingStageModel.recipeId;
    }
  }
}
