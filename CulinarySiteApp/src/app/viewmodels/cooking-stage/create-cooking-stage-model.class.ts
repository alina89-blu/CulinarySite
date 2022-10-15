import { ICreateCookingStageModel } from 'src/app/interfaces/cooking-stage/create-cooking-stage-model.interface';

export class CreateCookingStageModel {
  public content: string;
  public recipeId: number;
  public imageUrl: string;

  constructor(public createCookingStageModel?: ICreateCookingStageModel) {
    if (createCookingStageModel) {
      this.content = createCookingStageModel.content;
      this.recipeId = createCookingStageModel.recipeId;
      this.imageUrl = createCookingStageModel.imageUrl;
    }
  }
}
