import { ICreateOrganicMatterModel } from 'src/app/interfaces/organic-matter/create-organic-matter-model.interface';

export class CreateOrganicMatterModel {
  public name: string;

  constructor(public createOrganicMatterModel?: ICreateOrganicMatterModel) {
    if (createOrganicMatterModel) {
      this.name = createOrganicMatterModel.name;
    }
  }
}
