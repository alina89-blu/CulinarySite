import { Unit } from 'src/app/enums/unit.enum';
import { IRecipeOrganicMatterDetailModel } from 'src/app/interfaces/recipe-organic-matter/recipe-organic-matter-detail-model.interface';
import { IUpdateRecipeOrganicMatterModel } from 'src/app/interfaces/recipe-organic-matter/update-recipe-organic-matter-model.interface';

export class UpdateRecipeOrganicMatterModel {
  public recipeOrganicMatterId: number;
  public organicMatterId: number;
  public unit: Unit;
  public quantity: number;

  constructor(
    public updateRecipeOrganicMatterModel?:
      | IUpdateRecipeOrganicMatterModel
      | IRecipeOrganicMatterDetailModel
  ) {
    if (updateRecipeOrganicMatterModel) {
      this.recipeOrganicMatterId =
        updateRecipeOrganicMatterModel.recipeOrganicMatterId;
      this.organicMatterId = updateRecipeOrganicMatterModel.organicMatterId;
      this.unit = updateRecipeOrganicMatterModel.unit;
      this.quantity = updateRecipeOrganicMatterModel.quantity;
    }
  }
}
