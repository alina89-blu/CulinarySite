import { IIngredientDetailModel } from 'src/app/interfaces/ingredient/ingredient-detail-model.interface';

export class IngredientDetailModel {
  public ingredientId: number;
  public name: string;

  constructor(public ingredientDetailModel?: IIngredientDetailModel) {
    if (ingredientDetailModel) {
      this.ingredientId = ingredientDetailModel.ingredientId;
      this.name = ingredientDetailModel.name;
    }
  }
}
