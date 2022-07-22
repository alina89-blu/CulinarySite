import { ICreateAuthorModel } from 'src/app/interfaces/author/create-author-model.interface';
import { BookModel } from '../book/book-model.class';

export class CreateAuthorModel {
  public name: string;

  constructor(public createAuthorModel?: ICreateAuthorModel) {
    if (createAuthorModel) {
      this.name = createAuthorModel.name;
    }
  }
}
