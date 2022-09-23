import { Unit } from 'src/app/enums/unit.enum';
import { IIngredientModel } from 'src/app/interfaces/ingredient/ingredient-model.interface';

export class IngredientModel {
  public ingredientId: number;
  public name: string;
  public unit: Unit;
  public quantity: number;

  constructor(public ingredientModel?: IIngredientModel) {
    if (ingredientModel) {
      this.ingredientId = ingredientModel.ingredientId;
      this.name = ingredientModel.name;
      this.unit = ingredientModel.unit;
      this.quantity = ingredientModel.quantity;
    }
  }
}
