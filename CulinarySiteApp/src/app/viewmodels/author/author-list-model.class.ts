import { IAuthorListModel } from 'src/app/interfaces/author/author-list-model.interface';
import { BookModel } from '../book/book-model.class';
import { RecipeModel } from '../recipe/recipe-model.class';

export class AuthorListModel {
  public authorId: number;
  public name: string;
  public recipeModels: RecipeModel[];
  public books: BookModel[];

  constructor(public authorListModel?: IAuthorListModel) {
    if (authorListModel) {
      this.authorId = authorListModel.authorId;
      this.name = authorListModel.name;
      this.recipeModels = authorListModel.recipeModels;
      this.books = authorListModel.books;
    }
  }
}
