import { Unit } from 'src/app/enums/unit.enum';

export interface ICreateIngredientModel {
  ingredientId: number;
  name: string;
  unit: Unit;
  quantity: number;
}
