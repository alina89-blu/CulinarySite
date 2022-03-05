import { IIngredientDetailModel } from 'src/app/interfaces/ingredient/ingredient-detail-model.interface';
import { IUpdateIngredientModel } from 'src/app/interfaces/ingredient/update-ingredient-model.interface';

export class UpdateIngredientModel {
  public ingredientId: number;
  public name: string;

  constructor(
    public updateIngredientModel?:
      | IUpdateIngredientModel
      | IIngredientDetailModel
  ) {
    if (updateIngredientModel) {
      this.ingredientId = updateIngredientModel.ingredientId;
      this.name = updateIngredientModel.name;
    }
  }
}
