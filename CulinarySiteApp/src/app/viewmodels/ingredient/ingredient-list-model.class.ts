import { Unit } from 'src/app/enums/unit.enum';
import { IIngredientListModel } from 'src/app/interfaces/ingredient/ingredient-list-model.interface';

export class IngredientListModel {
  public ingredientId: number;
  public name: string;
  public unit: Unit;
  public quantity: number;

  constructor(public ingredientListModel?: IIngredientListModel) {
    if (ingredientListModel) {
      this.ingredientId = ingredientListModel.ingredientId;
      this.name = ingredientListModel.name;
      this.unit = ingredientListModel.unit;
      this.quantity = ingredientListModel.quantity;
    }
  }
}
