import { ICreateBookModel } from 'src/app/interfaces/book/create-book-model.interface';

export class CreateBookModel {
  public authorId: number;
  public name: string;
  public creationYear: number;
  public description: string;

  constructor(public createBookModel?: ICreateBookModel) {
    if (createBookModel) {
      this.authorId = createBookModel.authorId;
      this.name = createBookModel.name;
      this.creationYear = createBookModel.creationYear;
      this.description = createBookModel.description;
    }
  }
}
