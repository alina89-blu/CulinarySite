import { IOrganicMatter } from '../interfaces/organic-matter.interface';
import { OrganicMatterName } from '../enums/organic-matter-name.enum';
import { Unit } from '../enums/unit.enum';
import { Recipe } from './recipe.class';

export class OrganicMatter {
  public id: number;
  public name: OrganicMatterName;
  public unit: Unit;
  public quantity: number;
  public recipes?: Recipe[];

  constructor(public organicMatter?: IOrganicMatter) {
    if (organicMatter) {
      this.id = organicMatter.id;
      this.name = organicMatter.name;
      this.unit = organicMatter.unit;
      this.quantity = organicMatter.quantity;
      this.recipes = organicMatter.recipes;
    }
  }
}
