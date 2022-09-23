import { Unit } from 'src/app/enums/unit.enum';
import { IngredientDetailModel } from 'src/app/viewmodels/ingredient/ingredient-detail-model.class';

export interface IIngredientModel {
  ingredientId: number;
  name: string;
  unit: Unit;
  quantity: number;
}
