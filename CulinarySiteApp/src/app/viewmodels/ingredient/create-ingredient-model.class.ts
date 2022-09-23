import { Unit } from 'src/app/enums/unit.enum';
import { ICreateIngredientModel } from 'src/app/interfaces/ingredient/create-ingredient-model.interface';

export class CreateIngredientModel {
  public ingredientId: number; //
  public name: string;
  public unit: Unit;
  public quantity: number;

  constructor(public createIngredientModel?: ICreateIngredientModel) {
    if (createIngredientModel) {
      this.ingredientId = createIngredientModel.ingredientId;
      this.name = createIngredientModel.name;
      this.unit = createIngredientModel.unit;
      this.quantity = createIngredientModel.quantity;
    }
  }
}
