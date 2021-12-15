import { Episode } from '../viewmodels/episode.class';
import { Recipe } from '../viewmodels/recipe.class';

export interface ITag {
  id: number;
  text: string;
  recipes: Recipe[];
  episodes: Episode[];
}
