import { Unit } from 'src/app/enums/unit.enum';

export interface IRecipeOrganicMatterDetailModel {
  recipeOrganicMatterId: number;
  organicMatterId: number;
  unit: Unit;
  quantity: number;
}
