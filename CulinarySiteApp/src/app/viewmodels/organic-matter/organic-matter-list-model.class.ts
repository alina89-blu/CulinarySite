import { Unit } from 'src/app/enums/unit.enum';
import { IOrganicMatterListModel } from 'src/app/interfaces/organic-matter/organic-matter-list-model.interface';

export class OrganicMatterListModel {
  public organicMatterId: number;
  public name: string;
  public unit: Unit;
  public quantity: number;

  constructor(public organicMatterListModel?: IOrganicMatterListModel) {
    if (organicMatterListModel) {
      this.organicMatterId = organicMatterListModel.organicMatterId;
      this.name = organicMatterListModel.name;
      this.unit = organicMatterListModel.unit;
      this.quantity = organicMatterListModel.quantity;
    }
  }
}
