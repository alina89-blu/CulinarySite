import { Unit } from 'src/app/enums/unit.enum';

export interface IUpdateOrganicMatterModel {
  organicMatterId: number;
  name: string;
  unit: Unit;
  quantity: number;
}
