import { Book } from './book.class';
import { Dish } from './dish.class';
import { Episode } from './episode.class';
import { CookingStage } from './cooking-stage.class';
import { IImage } from '../interfaces/image.interface';

export class Image {
  public id: number;
  public name: string;
  public books?: Book[];
  public dishId?: number;
  public dish?: Dish;
  public episodeId?: number;
  public episode?: Episode;
  public cookingStageId?: number;
  public cookingStage?: CookingStage;

  constructor(public image?: IImage) {
    if (image) {
      this.id = image.id;
      this.name = image.name;
      this.books = image.books;
      this.dishId = image.dishId;
      this.dish = image.dish;
      this.episodeId = image.episodeId;
      this.episode = image.episode;
      this.cookingStageId = image.cookingStageId;
      this.cookingStage = image.cookingStage;
    }
  }
}
