import { IAuthor } from '../interfaces/author.interface';
import { Book } from './book.class';
import { Recipe } from './recipe.class';

export class Author {
  public id: number;
  public name: string;
  public books: Book[];
  public recipes: Recipe[];

  constructor(public author?: IAuthor) {
    if (author) {
      this.id = author.id;
      this.name = author.name;
      this.books = author.books;
      this.recipes = author.recipes;
    }
  }
}
