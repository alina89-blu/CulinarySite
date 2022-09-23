import { Unit } from 'src/app/enums/unit.enum';

export interface IOrganicMatterDetailModel {
  organicMatterId: number;
  name: string;
  unit: Unit;
  quantity: number;
}
