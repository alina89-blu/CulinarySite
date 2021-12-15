import { DifficultyLevel } from '../enums/difficulty-level.enum';
import { Ingredient } from './ingredient.class';
import { OrganicMatter } from './organic-matter.class';
import { CookingStage } from './cooking-stage.class';
import { Author } from './author.class';
import { Book } from './book.class';
import { Dish } from './dish.class';
import { Tag } from './tag.class';
import { IRecipe } from '../interfaces/recipe.interface';

export class Recipe {
  public id: number;
  public name: string;
  public servingsNumber: number;
  public cookingTime: Date = new Date();
  public difficultyLevel: DifficultyLevel;
  public content: string;
  public ingredients: Ingredient[];
  public organicMatters?: OrganicMatter[];
  public cookingStages: CookingStage[];
  public tags?: Tag[];
  public authorId: number;
  public author: Author;
  public bookId?: number;
  public book?: Book;
  public dishId: number;
  public dish: Dish;

  constructor(public recipe?: IRecipe) {
    if (recipe) {
      this.id = recipe.id;
      this.name = recipe.name;
      this.servingsNumber = recipe.servingsNumber;
      this.cookingTime = recipe.cookingTime;
      this.difficultyLevel = recipe.difficultyLevel;
      this.content = recipe.content;
      this.ingredients = recipe.ingredients;
      this.organicMatters = recipe.organicMatters;
      this.cookingStages = recipe.cookingStages;
      this.tags = recipe.tags;
      this.authorId = recipe.authorId;
      this.author = recipe.author;
      this.bookId = recipe.bookId;
      this.book = recipe.book;
      this.dishId = recipe.dishId;
      this.dish = recipe.dish;
    }
  }
}
