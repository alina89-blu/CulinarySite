import { Unit } from 'src/app/enums/unit.enum';

export interface ICreateRecipeOrganicMatterModel {
  recipeOrganicMatterId: number;
  organicMatterId: number;
  unit: Unit;
  quantity: number;
}
