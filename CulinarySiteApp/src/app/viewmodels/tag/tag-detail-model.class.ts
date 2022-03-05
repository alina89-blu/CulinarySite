import { ITagDetailModel } from 'src/app/interfaces/tag/tag-detail-model.interface';

export class TagDetailModel {
  public tagId: number;
  public text: string;

  constructor(public tagDetailModel?: ITagDetailModel) {
    if (tagDetailModel) {
      this.tagId = tagDetailModel.tagId;
      this.text = tagDetailModel.text;
    }
  }
}
