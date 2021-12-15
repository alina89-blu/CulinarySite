import { Book } from '../viewmodels/book.class';
import { CookingStage } from '../viewmodels/cooking-stage.class';
import { Dish } from '../viewmodels/dish.class';
import { Episode } from '../viewmodels/episode.class';

export interface IImage {
  id: number;
  name: string;
  books: Book[];
  dishId: number;
  dish: Dish;
  episodeId: number;
  episode: Episode;
  cookingStageId: number;
  cookingStage: CookingStage;
}
