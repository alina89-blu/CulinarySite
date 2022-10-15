import { IEpisodeListModel } from 'src/app/interfaces/episode/episode-list-model.interface';

export class EpisodeListModel {
  public episodeId: number;
  public name: string;
  public culinaryChannelName: string;
  public imageUrl: string;
  public videoUrl: string;
  //public culinaryChannelId: number;

  constructor(public episodeListModel?: IEpisodeListModel) {
    if (episodeListModel) {
      this.episodeId = episodeListModel.episodeId;
      this.name = episodeListModel.name;
      this.culinaryChannelName = episodeListModel.culinaryChannelName;
      this.imageUrl = episodeListModel.imageUrl;
      this.videoUrl = episodeListModel.videoUrl;
    }
  }
}
