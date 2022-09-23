import { Unit } from 'src/app/enums/unit.enum';
import { IOrganicMatterModel } from 'src/app/interfaces/organic-matter/organic-matter-model.interface';

export class OrganicMatterModel {
  public organicMatterId: number;
  public name: string;
  public unit: Unit;
  public quantity: number;

  constructor(public organicMatterModel?: IOrganicMatterModel) {
    if (organicMatterModel) {
      this.organicMatterId = organicMatterModel.organicMatterId;
      this.name = organicMatterModel.name;
      this.unit = organicMatterModel.unit;
      this.quantity = organicMatterModel.quantity;
    }
  }
}
