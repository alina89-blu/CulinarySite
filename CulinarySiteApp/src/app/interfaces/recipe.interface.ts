import { DifficultyLevel } from '../enums/difficulty-level.enum';
import { Author } from '../viewmodels/author.class';
import { Book } from '../viewmodels/book.class';
import { CookingStage } from '../viewmodels/cooking-stage.class';
import { Dish } from '../viewmodels/dish.class';
import { Ingredient } from '../viewmodels/ingredient.class';
import { OrganicMatter } from '../viewmodels/organic-matter.class';
import { Tag } from '../viewmodels/tag.class';

export interface IRecipe {
  id: number;
  name: string;
  servingsNumber: number;
  cookingTime: Date;
  difficultyLevel: DifficultyLevel;
  content: string;
  ingredients: Ingredient[];
  organicMatters: OrganicMatter[];
  cookingStages: CookingStage[];
  tags: Tag[];
  authorId: number;
  author: Author;
  bookId: number;
  book: Book;
  dishId: number;
  dish: Dish;
}
