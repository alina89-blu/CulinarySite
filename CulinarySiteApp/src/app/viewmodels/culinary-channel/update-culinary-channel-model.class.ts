import { ICulinaryChannelDetail } from 'src/app/interfaces/culinary-channel/culinary-channel-detail.interface';
import { IUpdateCulinaryChannelModel } from 'src/app/interfaces/culinary-channel/update-culinary-channel-model.interface';

export class UpdateCulinaryChannelModel {
  public culinaryChannelId: number;
  public name: string;
  public content: string;

  constructor(
    public updateCulinaryChannelModel?:
      | IUpdateCulinaryChannelModel
      | ICulinaryChannelDetail
  ) {
    if (updateCulinaryChannelModel) {
      this.culinaryChannelId = updateCulinaryChannelModel.culinaryChannelId;
      this.name = updateCulinaryChannelModel.name;
      this.content = updateCulinaryChannelModel.content;
    }
  }
}
