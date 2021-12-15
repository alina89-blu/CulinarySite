import { ICulinaryChannel } from '../interfaces/culinary-channel.interface';
import { Episode } from './episode.class';

export class CulinaryChannel {
  public id: number;
  public name: string;
  public episodes: Episode[];

  constructor(public culinaryChannel?: ICulinaryChannel) {
    if (culinaryChannel) {
      this.id = culinaryChannel.id;
      this.name = culinaryChannel.name;
      this.episodes = culinaryChannel.episodes;
    }
  }
}
