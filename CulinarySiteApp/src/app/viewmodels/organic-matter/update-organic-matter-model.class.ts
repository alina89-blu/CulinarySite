import { Unit } from 'src/app/enums/unit.enum';
import { IOrganicMatterDetailModel } from 'src/app/interfaces/organic-matter/organic-matter-detail-model.interface';
import { IUpdateOrganicMatterModel } from 'src/app/interfaces/organic-matter/update-organic-matter-model.interface';

export class UpdateOrganicMatterModel {
  public organicMatterId: number;
  public name: string;
  public unit: Unit;
  public quantity: number;

  constructor(
    public updateOrganicMatterModel?:
      | IUpdateOrganicMatterModel
      | IOrganicMatterDetailModel
  ) {
    if (updateOrganicMatterModel) {
      this.organicMatterId = updateOrganicMatterModel.organicMatterId;
      this.name = updateOrganicMatterModel.name;
      this.unit = updateOrganicMatterModel.unit;
      this.quantity = updateOrganicMatterModel.quantity;
    }
  }
}
