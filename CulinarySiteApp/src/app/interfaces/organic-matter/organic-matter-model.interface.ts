import { Unit } from 'src/app/enums/unit.enum';

export interface IOrganicMatterModel {
  organicMatterId: number;
  name: string;
  unit: Unit;
  quantity: number;
}
