import { Component, OnInit } from '@angular/core';
import { DifficultyLevel } from 'src/app/enums/difficulty-level.enum';
import { RecipeService } from 'src/app/services/recipe.service';
import { ActivatedRoute, Router } from '@angular/router';
import { DishService } from 'src/app/services/dish.service';
import { UpdateRecipeModel } from 'src/app/viewmodels/recipe/update-recipe-model.class';
import { IRecipeDetailModel } from 'src/app/interfaces/recipe/recipe-detail-model.interface';
import {
  FormBuilder,
  FormControl,
  FormGroup,
  Validators,
} from '@angular/forms';
import { IngredientListModel } from 'src/app/viewmodels/ingredient/ingredient-list-model.class';
import { AuthorService } from 'src/app/services/author.service';
import { BookService } from 'src/app/services/book.service';
import { BookModel } from 'src/app/viewmodels/book/book-model.class';
import { IBookModel } from 'src/app/interfaces/book/book-model.interface';
import { Unit } from 'src/app/enums/unit.enum';
import { AuthorListModel } from 'src/app/viewmodels/author/author-list-model.class';
import { IAuthorListModel } from 'src/app/interfaces/author/author-list-model.interface';
import { DishModel } from 'src/app/viewmodels/dish/dish-model.class';
import { IDishModel } from 'src/app/interfaces/dish/dish-model.interface';

@Component({
  selector: 'app-recipe-edit',
  templateUrl: './recipe-edit.component.html',
  styleUrls: ['./recipe-edit.component.css'],
})
export class RecipeEditComponent implements OnInit {
  private id: number;
  public updateRecipeModel: UpdateRecipeModel = new UpdateRecipeModel();
  public difficultyLevels: DifficultyLevel[] = [
    DifficultyLevel.Лёгкий,
    DifficultyLevel['Очень Лёгкий'],
    DifficultyLevel.Средний,
    DifficultyLevel['Выше cреднего'],
    DifficultyLevel.Сложный,
  ];
  public units: Unit[] = [
    Unit.Грамм,
    Unit.Калории,
    Unit.Килограмм,
    Unit.Кусок,
    Unit.Литр,
    Unit.Миллилитр,
    Unit.Штука,
  ];
  public dishes: DishModel[] = [];
  public authors: AuthorListModel[] = [];
  public books: BookModel[] = [];
  public myForm: FormGroup;

  constructor(
    private readonly recipeService: RecipeService,
    private readonly dishService: DishService,
    private readonly router: Router,
    private readonly formBuilder: FormBuilder,
    private readonly authorService: AuthorService,
    private readonly bookService: BookService,
    activeRoute: ActivatedRoute
  ) {
    this.id = Number.parseInt(activeRoute.snapshot.params['id']);
  }

  public ngOnInit(): void {
    if (this.id) {
      this.recipeService
        .getRecipe(this.id, true)
        .subscribe((data: IRecipeDetailModel) => {
          this.updateRecipeModel = new UpdateRecipeModel(data);
        });
    }

    this.getDishList();
    this.getAuthorList();
    this.getBookList();

    this.myForm = new FormGroup({
      name: new FormControl('', [Validators.required, Validators.minLength(5)]),
      servingsNumber: new FormControl('', [
        Validators.required,
        Validators.min(1),
      ]),
      imageUrl: new FormControl('', Validators.required),
      cookingTime: new FormControl('', Validators.required),
      difficultyLevel: new FormControl('', Validators.required),
      content: new FormControl('', Validators.required),
      authorId: new FormControl('', Validators.required),
      bookId: new FormControl('', Validators.required),
      dishId: new FormControl('', Validators.required),
    });
  }

  public getBookList(): void {
    this.bookService
      .getBookList()
      .subscribe(
        (data: IBookModel[]) => (this.books = data.map((x) => new BookModel(x)))
      );
  }

  public getAuthorList(): void {
    this.authorService
      .getAuthorList()
      .subscribe(
        (data: IAuthorListModel[]) =>
          (this.authors = data.map((x) => new AuthorListModel(x)))
      );
  }

  public getDishList(): void {
    this.dishService
      .getDishList()
      .subscribe(
        (data: IDishModel[]) =>
          (this.dishes = data.map((x) => new DishModel(x)))
      );
  }

  public updateRecipe(): void {
    this.recipeService
      .updateRecipe(this.updateRecipeModel)
      .subscribe(() => this.router.navigateByUrl('recipe'));
  }
}
