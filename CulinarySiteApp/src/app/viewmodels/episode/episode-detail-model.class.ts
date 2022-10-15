import { IEpisodeDetailModel } from 'src/app/interfaces/episode/episode-detail-model.interface';

export class EpisodeDetailModel {
  public episodeId: number;
  public name: string;
  public culinaryChannelId: number;
  public imageUrl: string;
  public videoUrl: string;

  constructor(public episodeDetailModel?: IEpisodeDetailModel) {
    if (episodeDetailModel) {
      this.episodeId = episodeDetailModel.episodeId;
      this.name = episodeDetailModel.name;
      this.culinaryChannelId = episodeDetailModel.culinaryChannelId;
      this.imageUrl = episodeDetailModel.imageUrl;
      this.videoUrl = episodeDetailModel.videoUrl;
    }
  }
}
