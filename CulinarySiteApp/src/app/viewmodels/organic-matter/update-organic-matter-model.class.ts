import { IOrganicMatterDetailModel } from 'src/app/interfaces/organic-matter/organic-matter-detail-model.interface';
import { IUpdateOrganicMatterModel } from 'src/app/interfaces/organic-matter/update-organic-matter-model.interface';

export class UpdateOrganicMatterModel {
  public organicMatterId: number;
  public name: string;

  constructor(
    public updateOrganicMatterModel?:
      | IUpdateOrganicMatterModel
      | IOrganicMatterDetailModel
  ) {
    if (updateOrganicMatterModel) {
      this.organicMatterId = updateOrganicMatterModel.organicMatterId;
      this.name = updateOrganicMatterModel.name;
    }
  }
}
