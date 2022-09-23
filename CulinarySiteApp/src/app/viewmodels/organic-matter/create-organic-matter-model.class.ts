import { Unit } from 'src/app/enums/unit.enum';
import { ICreateOrganicMatterModel } from 'src/app/interfaces/organic-matter/create-organic-matter.model.interface';

export class CreateOrganicMatterModel {
  public name: string;
  public unit: Unit;
  public quantity: number;

  constructor(public createOrganicMatterModel?: ICreateOrganicMatterModel) {
    if (createOrganicMatterModel) {
      this.name = createOrganicMatterModel.name;
      this.unit = createOrganicMatterModel.unit;
      this.quantity = createOrganicMatterModel.quantity;
    }
  }
}
