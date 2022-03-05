import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { RecipeService } from 'src/app/services/recipe.service';
import { DifficultyLevel } from 'src/app/enums/difficulty-level.enum';
import { DishService } from 'src/app/services/dish.service';
import { CreateRecipeModel } from 'src/app/viewmodels/recipe/create-recipe-model.class';
import { DishListModel } from 'src/app/viewmodels/dish/dish-list-model.class';
import { IDishListModel } from 'src/app/interfaces/dish/dish-list-model.interface';
import { IngredientService } from 'src/app/services/ingredient.service';
import { IngredientListModel } from 'src/app/viewmodels/ingredient/ingredient-list-model.class';
import { IIngredientListModel } from 'src/app/interfaces/ingredient/ingredient-list-model.interface';
import { CreateRecipeIngredientModel } from 'src/app/viewmodels/recipe-ingredient/create-recipe-ingredient-model.class';
import { Unit } from 'src/app/enums/unit.enum';
import { AuthorService } from 'src/app/services/author.service';
import {
  FormArray,
  FormBuilder,
  FormControl,
  FormGroup,
  Validators,
} from '@angular/forms';
import { BookService } from 'src/app/services/book.service';
import { IBookModel } from 'src/app/interfaces/book/book-model.interface';
import { BookModel } from 'src/app/viewmodels/book/book-model.class';
import { AfterViewChecked, ChangeDetectorRef } from '@angular/core';
import { IAuthorModel } from 'src/app/interfaces/author/author-model.interface';
import { AuthorModel } from 'src/app/viewmodels/author/author-model.class';

@Component({
  selector: 'app-recipe-create',
  templateUrl: './recipe-create.component.html',
  styleUrls: ['./recipe-create.component.css'],
})
export class RecipeCreateComponent implements OnInit, AfterViewChecked {
  public createRecipeModel: CreateRecipeModel = new CreateRecipeModel();

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
  public dishes: DishListModel[] = [];
  public ingredients: IngredientListModel[] = [];
  public authors: AuthorModel[] = [];
  public books: BookModel[] = [];

  public showIngredients: boolean = false;

  public myForm: FormGroup;

  constructor(
    private recipeService: RecipeService,
    private router: Router,
    private dishService: DishService,
    private ingredientService: IngredientService,
    private authorService: AuthorService,
    private bookService: BookService,
    private formBuilder: FormBuilder,
    private readonly changeDetectorRef: ChangeDetectorRef
  ) {
    this.myForm = new FormGroup({
      name: new FormControl('recept', Validators.required),
      servingsNumber: new FormControl('', Validators.required),
      dish: new FormControl('', Validators.required),
      author: new FormControl('', Validators.required),
      book: new FormControl('', Validators.required),
      recipeIngredients: new FormArray([
        new FormGroup({
          ingredientId: new FormControl('', Validators.required),
          unit: new FormControl('', Validators.required),
          quantity: new FormControl('', Validators.required),
        }),
      ]),
    });
    this.createRecipeModel.recipeIngredients = [
      new CreateRecipeIngredientModel(),
    ];
  }

  public getFormsControls(): FormArray {
    return this.myForm.controls['recipeIngredients'] as FormArray;
  }

  public addRecipeIngredient(): void {
    (<FormArray>this.myForm.controls['recipeIngredients']).push(
      this.createNewRecipeIngredient()
    );

    this.createRecipeModel.recipeIngredients.push(
      new CreateRecipeIngredientModel()
    );
  }

  public createNewRecipeIngredient(): FormGroup {
    const group = new FormGroup({
      ingredientId: new FormControl('', Validators.required),
      unit: new FormControl('', Validators.required),
      quantity: new FormControl('', Validators.required),
    });
    return group;
  }

  public ngOnInit(): void {
    this.getDishList();
    this.getIngredientList();
    this.getAuthorList();
    this.getBookList();
  }

  public addIngredients() {
    this.showIngredients = !this.showIngredients;
  }

  ngAfterViewChecked(): void {
    this.changeDetectorRef.detectChanges();
  }

  public createRecipe(): void {
    this.recipeService
      .createRecipe(this.createRecipeModel)
      .subscribe(() => this.router.navigateByUrl('recipe'));
  }

  public getDishList(): void {
    this.dishService
      .getDishList(false)
      .subscribe(
        (data: IDishListModel[]) =>
          (this.dishes = data.map((x) => new DishListModel(x)))
      );
  }

  public getIngredientList(): void {
    this.ingredientService
      .getIngredientList(false)
      .subscribe(
        (data: IIngredientListModel[]) =>
          (this.ingredients = data.map((x) => new IngredientListModel(x)))
      );
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
        (data: IAuthorModel[]) =>
          (this.authors = data.map((x) => new AuthorModel(x)))
      );
  }

  public deleteRecipeIngredient(index: number) {
    this.getFormsControls().removeAt(index);
  }
}
