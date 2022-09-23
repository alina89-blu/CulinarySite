import { ITagModel } from 'src/app/interfaces/tag/tag-model.interface';

export class TagModel {
  public tagId: number;
  public text: string;

  constructor(public tagModel?: ITagModel) {
    if (tagModel) {
      this.tagId = tagModel.tagId;
      this.text = tagModel.text;
    }
  }
}
