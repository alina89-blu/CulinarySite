import { Author } from '../viewmodels/author.class';
import { Recipe } from '../viewmodels/recipe.class';
import { Image } from '../viewmodels/image.class';

export interface IBook {
  id: number;
  name: string;
  creationYear: Date;
  authorId: number;
  author: Author;
  recipes: Recipe[];
  images: Image[];
}
