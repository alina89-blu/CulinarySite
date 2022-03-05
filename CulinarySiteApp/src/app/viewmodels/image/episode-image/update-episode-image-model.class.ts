import { IEpisodeImageDetailModel } from 'src/app/interfaces/image/episode-image/episode-image-detail-model.interface';
import { IUpdateEpisodeImageModel } from 'src/app/interfaces/image/episode-image/update-episode-image-model.interface';

export class UpdateEpisodeImageModel {
  public episodeImageId: number;
  public name: string;
  public url: string;
  public episodeId: number;

  constructor(
    public updateEpisodeImageModel?:
      | IUpdateEpisodeImageModel
      | IEpisodeImageDetailModel
  ) {
    if (updateEpisodeImageModel) {
      this.episodeImageId = updateEpisodeImageModel.episodeImageId;
      this.name = updateEpisodeImageModel.name;
      this.url = updateEpisodeImageModel.url;
      this.episodeId = updateEpisodeImageModel.episodeId;
    }
  }
}
