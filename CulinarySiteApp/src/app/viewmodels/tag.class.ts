import { Recipe } from './recipe.class';
import { Episode } from './episode.class';
import { ITag } from '../interfaces/tag.interface';

export class Tag {
  public id: number;
  public text: string;
  public recipes: Recipe[];
  public episodes: Episode[];

  constructor(public tag?: ITag) {
    if (tag) {
      this.id = tag.id;
      this.text = tag.text;
      this.recipes = tag.recipes;
      this.episodes = tag.episodes;
    }
  }
}
