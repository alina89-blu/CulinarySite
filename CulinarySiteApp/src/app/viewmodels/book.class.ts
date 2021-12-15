import { Author } from './author.class';
import { IBook } from '../interfaces/book.interface';
import { Recipe } from './recipe.class';
import { Image } from './image.class';

export class Book {
  public id: number;
  public name: string;
  public creationYear: Date = new Date();
  public recipes: Recipe[];
  public images: Image[];
  public authorId: number;
  public author: Author;

  constructor(public book?: IBook) {
    if (book) {
      this.id = book.id;
      this.name = book.name;
      this.creationYear = book.creationYear;
      this.recipes = book.recipes;
      this.images = book.images;
      this.authorId = book.authorId;
      this.author = book.author;
    }
  }
}
