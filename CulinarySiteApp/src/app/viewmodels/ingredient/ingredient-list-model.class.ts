import { IIngredientListModel } from 'src/app/interfaces/ingredient/ingredient-list-model.interface';

export class IngredientListModel {
  public ingredientId: number;
  public name: string;

  constructor(public ingredientListModel?: IIngredientListModel) {
    if (ingredientListModel) {
      this.ingredientId = ingredientListModel.ingredientId;
      this.name = ingredientListModel.name;
    }
  }
}
