import { Unit } from 'src/app/enums/unit.enum';

export interface ICreateOrganicMatterModel {
  name: string;
  unit: Unit;
  quantity: number;
}
