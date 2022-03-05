import { IEpisodeImageDetailModel } from 'src/app/interfaces/image/episode-image/episode-image-detail-model.interface';

export class EpisodeImageDetailModel {
  public episodeImageId: number;
  public name: string;
  public url: string;
  public episodeId: number;

  constructor(public episodeImageDetailModel?: IEpisodeImageDetailModel) {
    if (episodeImageDetailModel) {
      this.episodeImageId = episodeImageDetailModel.episodeImageId;
      this.name = episodeImageDetailModel.name;
      this.url = episodeImageDetailModel.url;
      this.episodeId = episodeImageDetailModel.episodeId;
    }
  }
}
