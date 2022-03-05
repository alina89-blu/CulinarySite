import { ITagDetailModel } from 'src/app/interfaces/tag/tag-detail-model.interface';
import { IUpdateTagModel } from 'src/app/interfaces/tag/update-tag-model.interface';

export class UpdateTagModel {
  public tagId: number;
  public text: string;

  constructor(public updateTagModel?: IUpdateTagModel | ITagDetailModel) {
    if (updateTagModel) {
      this.tagId = updateTagModel.tagId;
      this.text = updateTagModel.text;
    }
  }
}
