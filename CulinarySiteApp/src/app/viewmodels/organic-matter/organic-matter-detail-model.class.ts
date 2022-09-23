import { Unit } from 'src/app/enums/unit.enum';
import { IOrganicMatterDetailModel } from 'src/app/interfaces/organic-matter/organic-matter-detail-model.interface';

export class OrganicMatterDetailModel {
  public organicMatterId: number;
  public name: string;
  public unit: Unit;
  public quantity: number;

  constructor(public organicMatterDetailModel?: IOrganicMatterDetailModel) {
    if (organicMatterDetailModel) {
      this.organicMatterId = organicMatterDetailModel.organicMatterId;
      this.name = organicMatterDetailModel.name;
      this.unit = organicMatterDetailModel.unit;
      this.quantity = organicMatterDetailModel.quantity;
    }
  }
}
