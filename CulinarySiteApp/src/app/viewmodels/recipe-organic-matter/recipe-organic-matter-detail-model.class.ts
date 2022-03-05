import { Unit } from 'src/app/enums/unit.enum';
import { IRecipeOrganicMatterDetailModel } from 'src/app/interfaces/recipe-organic-matter/recipe-organic-matter-detail-model.interface';

export class RecipeOrganicMatterDetailModel {
  public recipeOrganicMatterId: number;
  public organicMatterId: number;
  public unit: Unit;
  public quantity: number;

  constructor(
    public recipeOrganicMatterDetailModel?: IRecipeOrganicMatterDetailModel
  ) {
    if (recipeOrganicMatterDetailModel) {
      this.recipeOrganicMatterId =
        recipeOrganicMatterDetailModel.recipeOrganicMatterId;
      this.organicMatterId = recipeOrganicMatterDetailModel.organicMatterId;
      this.unit = recipeOrganicMatterDetailModel.unit;
      this.quantity = recipeOrganicMatterDetailModel.quantity;
    }
  }
}
