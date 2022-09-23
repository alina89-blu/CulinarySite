import { Unit } from 'src/app/enums/unit.enum';

export interface IUpdateIngredientModel {
  ingredientId: number;
  name: string;
  unit: Unit;
  quantity: number;
}
