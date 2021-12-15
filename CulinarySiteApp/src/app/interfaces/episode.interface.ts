import { CulinaryChannel } from '../viewmodels/culinary-channel.class';
import { Image } from '../viewmodels/image.class';
import { Tag } from '../viewmodels/tag.class';

export interface IEpisode {
  id: number;
  name: string;
  culinaryChannelId: number;
  culinaryChannel: CulinaryChannel;
  image: Image;
  tags: Tag[];
}
