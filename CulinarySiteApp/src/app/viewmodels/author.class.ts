import { IAuthor } from '../interfaces/author.interface';

export class Author {
  public id: number;
  public name: string;

  constructor(public author?: IAuthor) {
    if (author) {
      this.id = author.id;
      this.name = author.name;
    }
  }
}
