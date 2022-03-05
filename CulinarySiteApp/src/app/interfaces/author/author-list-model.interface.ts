import { BookModel } from 'src/app/viewmodels/book/book-model.class';
import { RecipeListModel } from 'src/app/viewmodels/recipe/recipe-list-model.class';
import { RecipeModel } from 'src/app/viewmodels/recipe/recipe-model.class';

export interface IAuthorListModel {
  authorId: number;
  name: string;
  recipeModels: RecipeModel[];
  books: BookModel[];
}
