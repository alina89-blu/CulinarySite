import { ICulinaryChannelListModel } from 'src/app/interfaces/culinary-channel/culinary-channel-list-model.interface';

export class CulinaryChannelListModel {
  public culinaryChannelId: number;
  public name: string;
  public content: string;

  constructor(public culinaryChannelListModel?: ICulinaryChannelListModel) {
    if (culinaryChannelListModel) {
      this.culinaryChannelId = culinaryChannelListModel.culinaryChannelId;
      this.name = culinaryChannelListModel.name;
      this.content = culinaryChannelListModel.content;
    }
  }
}
