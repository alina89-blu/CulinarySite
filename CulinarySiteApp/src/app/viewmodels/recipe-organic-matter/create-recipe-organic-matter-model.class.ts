import { Unit } from 'src/app/enums/unit.enum';
import { ICreateRecipeOrganicMatterModel } from 'src/app/interfaces/recipe-organic-matter/create-recipe-organic-matter.model.interface';

export class CreateRecipeOrganicMatterModel {
  public recipeOrganicMatterId: number;
  public organicMatterId: number;
  public unit: Unit;
  public quantity: number;

  constructor(
    public createRecipeOrganicMatterModel?: ICreateRecipeOrganicMatterModel
  ) {
    if (createRecipeOrganicMatterModel) {
      this.recipeOrganicMatterId =
        createRecipeOrganicMatterModel.recipeOrganicMatterId;
      this.organicMatterId = createRecipeOrganicMatterModel.organicMatterId;
      this.unit = createRecipeOrganicMatterModel.unit;
      this.quantity = createRecipeOrganicMatterModel.quantity;
    }
  }
}
