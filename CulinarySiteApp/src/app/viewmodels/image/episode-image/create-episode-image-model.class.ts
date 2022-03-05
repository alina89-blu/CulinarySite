import { ICreateEpisodeImageModel } from 'src/app/interfaces/image/episode-image/create-episode-image-model.interface';

export class CreateEpisodeImageModel {
  public name: string;
  public url: string;
  public episodeId: number;

  constructor(public createEpisodeImageModel?: ICreateEpisodeImageModel) {
    if (createEpisodeImageModel) {
      this.name = createEpisodeImageModel.name;
      this.url = createEpisodeImageModel.url;
      this.episodeId = createEpisodeImageModel.episodeId;
    }
  }
}
