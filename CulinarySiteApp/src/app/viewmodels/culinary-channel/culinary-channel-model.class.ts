import { ICulinaryChannelModel } from 'src/app/interfaces/culinary-channel/culinary-channel.interface';

export class CulinaryChannelModel {
  public culinaryChannelId: number;
  public name: string;

  constructor(public culinaryChannelModel?: ICulinaryChannelModel) {
    if (culinaryChannelModel) {
      this.culinaryChannelId = culinaryChannelModel.culinaryChannelId;
      this.name = culinaryChannelModel.name;
    }
  }
}
