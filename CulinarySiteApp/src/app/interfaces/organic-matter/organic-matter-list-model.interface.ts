import { Unit } from 'src/app/enums/unit.enum';

export interface IOrganicMatterListModel {
  organicMatterId: number;
  name: string;
  unit: Unit;
  quantity: number;
}
