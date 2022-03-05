import { ICreateCulinaryChannelModel } from 'src/app/interfaces/culinary-channel/create-culinary-channel-model.interface';

export class CreateCulinaryChannelModel {
  public name: string;
  public content: string;

  constructor(public createCulinaryChannelModel?: ICreateCulinaryChannelModel) {
    if (createCulinaryChannelModel) {
      this.name = createCulinaryChannelModel.name;
      this.content = createCulinaryChannelModel.content;
    }
  }
}
