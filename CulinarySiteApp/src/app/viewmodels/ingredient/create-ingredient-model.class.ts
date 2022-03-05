import { ICreateIngredientModel } from 'src/app/interfaces/ingredient/create-ingredient-model.interface';

export class CreateIngredientModel {
  public name: string;

  constructor(public createIngredientModel?: ICreateIngredientModel) {
    if (createIngredientModel) {
      this.name = createIngredientModel.name;
    }
  }
}
