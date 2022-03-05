import { ICulinaryChannelDetail } from 'src/app/interfaces/culinary-channel/culinary-channel-detail.interface';

export class CulinaryChannelDetail {
  public culinaryChannelId: number;
  public name: string;
  public content: string;

  constructor(public culinaryChannelDetail?: ICulinaryChannelDetail) {
    if (culinaryChannelDetail) {
      this.culinaryChannelId = culinaryChannelDetail.culinaryChannelId;
      this.name = culinaryChannelDetail.name;
      this.content = culinaryChannelDetail.content;
    }
  }
}
