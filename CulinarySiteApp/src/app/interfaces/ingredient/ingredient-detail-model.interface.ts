import { Unit } from 'src/app/enums/unit.enum';

export interface IIngredientDetailModel {
  ingredientId: number;
  name: string;
  unit: Unit;
  quantity: number;
}
