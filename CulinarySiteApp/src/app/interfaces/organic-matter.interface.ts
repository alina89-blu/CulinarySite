import { OrganicMatterName } from '../enums/organic-matter-name.enum';
import { Unit } from '../enums/unit.enum';
import { Recipe } from '../viewmodels/recipe.class';

export interface IOrganicMatter {
  id: number;
  name: OrganicMatterName;
  unit: Unit;
  quantity: number;
  recipes: Recipe[];
}
