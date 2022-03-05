import { IEpisodeImageListModel } from 'src/app/interfaces/image/episode-image/episode-image-list-model.interface';

export class EpisodeImageListModel {
  public episodeImageId: number;
  public name: string;
  public url: string;
  public episodeName: number;

  constructor(public episodeImageListModel?: IEpisodeImageListModel) {
    if (episodeImageListModel) {
      this.episodeImageId = episodeImageListModel.episodeImageId;
      this.name = episodeImageListModel.name;
      this.url = episodeImageListModel.url;
      this.episodeName = episodeImageListModel.episodeName;
    }
  }
}
