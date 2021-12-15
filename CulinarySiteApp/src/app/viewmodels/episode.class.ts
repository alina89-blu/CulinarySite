import { IEpisode } from '../interfaces/episode.interface';
import { CulinaryChannel } from './culinary-channel.class';
import { Image } from './image.class';
import { Tag } from './tag.class';

export class Episode {
  public id: number;
  public name: string;
  public culinaryChannelId: number;
  public culinaryChannel: CulinaryChannel;
  public image: Image;
  public tags: Tag[];

  constructor(public episode?: IEpisode) {
    if (episode) {
      this.id = episode.id;
      this.name = episode.name;
      this.culinaryChannelId = episode.culinaryChannelId;
      this.culinaryChannel = episode.culinaryChannel;
      this.image = episode.image;
      this.tags = episode.tags;
    }
  }
}
