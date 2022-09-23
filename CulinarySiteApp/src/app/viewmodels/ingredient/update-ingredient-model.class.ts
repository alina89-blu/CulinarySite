import { Unit } from 'src/app/enums/unit.enum';
import { IIngredientDetailModel } from 'src/app/interfaces/ingredient/ingredient-detail-model.interface';
import { IUpdateIngredientModel } from 'src/app/interfaces/ingredient/update-ingredient-model.interface';

export class UpdateIngredientModel {
  public ingredientId: number;
  public name: string;
  public unit: Unit;
  public quantity: number;

  constructor(
    public updateIngredientModel?:
      | IUpdateIngredientModel
      | IIngredientDetailModel
  ) {
    if (updateIngredientModel) {
      this.ingredientId = updateIngredientModel.ingredientId;
      this.name = updateIngredientModel.name;
      this.unit = updateIngredientModel.unit;
      this.quantity = updateIngredientModel.quantity;
    }
  }
}
