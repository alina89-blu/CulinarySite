import { Unit } from 'src/app/enums/unit.enum';
import { IRecipeOrganicMatterListModel } from 'src/app/interfaces/recipe-organic-matter/recipe-organic-matter-list-model.interface';

export class RecipeOrganicMatterListModel {
  public recipeOrganicMatterId: number;
  public organicMatterName: string;
  public unit: Unit;
  public quantity: number;

  constructor(
    public recipeOrganicMatterListModel?: IRecipeOrganicMatterListModel
  ) {
    if (recipeOrganicMatterListModel) {
      this.recipeOrganicMatterId =
        recipeOrganicMatterListModel.recipeOrganicMatterId;
      this.organicMatterName = recipeOrganicMatterListModel.organicMatterName;
      this.unit = recipeOrganicMatterListModel.unit;
      this.quantity = recipeOrganicMatterListModel.quantity;
    }
  }
}
