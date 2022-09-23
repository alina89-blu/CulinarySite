import { Unit } from 'src/app/enums/unit.enum';

export interface IIngredientListModel {
  ingredientId: number;
  name: string;
  unit: Unit;
  quantity: number;
}
