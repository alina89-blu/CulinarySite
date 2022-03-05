import { IOrganicMatterDetailModel } from 'src/app/interfaces/organic-matter/organic-matter-detail-model.interface';

export class OrganicMatterDetailModel {
  public organicMatterId: number;
  public name: string;

  constructor(public organicMatterDetailModel?: IOrganicMatterDetailModel) {
    if (organicMatterDetailModel) {
      this.organicMatterId = organicMatterDetailModel.organicMatterId;
      this.name = organicMatterDetailModel.name;
    }
  }
}
