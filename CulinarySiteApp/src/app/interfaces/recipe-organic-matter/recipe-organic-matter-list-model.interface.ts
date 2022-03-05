import { Unit } from 'src/app/enums/unit.enum';

export interface IRecipeOrganicMatterListModel {
  recipeOrganicMatterId: number;
  organicMatterName: string;
  unit: Unit;
  quantity: number;
}
