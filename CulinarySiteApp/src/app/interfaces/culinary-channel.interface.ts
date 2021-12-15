import { Episode } from '../viewmodels/episode.class';

export interface ICulinaryChannel {
  id: number;
  name: string;
  episodes: Episode[];
}
