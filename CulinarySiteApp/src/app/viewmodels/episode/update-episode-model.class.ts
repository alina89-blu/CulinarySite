import { IEpisodeDetailModel } from 'src/app/interfaces/episode/episode-detail-model.interface';
import { IUpdateEpisodeModel } from 'src/app/interfaces/episode/update-episode-model.interface';

export class UpdateEpisodeModel {
  public episodeId: number;
  public name: string;
  public culinaryChannelId: number;

  constructor(
    public updateEpisodeModel?: IUpdateEpisodeModel | IEpisodeDetailModel
  ) {
    if (updateEpisodeModel) {
      this.episodeId = updateEpisodeModel.episodeId;
      this.name = updateEpisodeModel.name;
      this.culinaryChannelId = updateEpisodeModel.culinaryChannelId;
    }
  }
}
