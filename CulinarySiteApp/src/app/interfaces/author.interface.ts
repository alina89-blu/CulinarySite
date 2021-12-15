import { Book } from '../viewmodels/book.class';
import { Recipe } from '../viewmodels/recipe.class';

export interface IAuthor {
  id: number;
  name: string;
  books: Book[];
  recipes: Recipe[];
}
