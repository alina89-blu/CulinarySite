import { ICreateEpisodeModel } from 'src/app/interfaces/episode/create-episode-model.interface';

export class CreateEpisodeModel {
  // public id: number;
  public name: string;
  public culinaryChannelId: number;

  constructor(public createEpisodeModel?: ICreateEpisodeModel) {
    if (createEpisodeModel) {
      this.name = createEpisodeModel.name;
      this.culinaryChannelId = createEpisodeModel.culinaryChannelId;
    }
  }
}
