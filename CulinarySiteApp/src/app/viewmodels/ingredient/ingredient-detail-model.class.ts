import { Unit } from 'src/app/enums/unit.enum';
import { IIngredientDetailModel } from 'src/app/interfaces/ingredient/ingredient-detail-model.interface';

export class IngredientDetailModel {
  public ingredientId: number;
  public name: string;
  public unit: Unit;
  public quantity: number;

  constructor(public ingredientDetailModel?: IIngredientDetailModel) {
    if (ingredientDetailModel) {
      this.ingredientId = ingredientDetailModel.ingredientId;
      this.name = ingredientDetailModel.name;
      this.unit = ingredientDetailModel.unit;
      this.quantity = ingredientDetailModel.quantity;
    }
  }
}
