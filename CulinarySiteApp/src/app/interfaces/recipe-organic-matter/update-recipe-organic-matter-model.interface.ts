import { Unit } from 'src/app/enums/unit.enum';

export interface IUpdateRecipeOrganicMatterModel {
  recipeOrganicMatterId: number;
  organicMatterId: number;
  unit: Unit;
  quantity: number;
}
