import { ITagListModel } from 'src/app/interfaces/tag/tag-list-model.interface';

export class TagListModel {
  public tagId: number;
  public text: string;

  constructor(public tagListModel?: ITagListModel) {
    if (tagListModel) {
      this.tagId = tagListModel.tagId;
      this.text = tagListModel.text;
    }
  }
}
