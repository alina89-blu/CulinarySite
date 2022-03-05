import { IOrganicMatterListModel } from 'src/app/interfaces/organic-matter/organic-matter-list-model.interface';

export class OrganicMatterListModel {
  public organicMatterId: number;
  public name: string;

  constructor(public organicMatterListModel?: IOrganicMatterListModel) {
    if (organicMatterListModel) {
      this.organicMatterId = organicMatterListModel.organicMatterId;
      this.name = organicMatterListModel.name;
    }
  }
}
