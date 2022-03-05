import { ICreateTagModel } from 'src/app/interfaces/tag/create-tag-model.interface';

export class CreateTagModel {
  public text: string;

  constructor(public createTagModel?: ICreateTagModel) {
    if (createTagModel) {
      this.text = createTagModel.text;
    }
  }
}
