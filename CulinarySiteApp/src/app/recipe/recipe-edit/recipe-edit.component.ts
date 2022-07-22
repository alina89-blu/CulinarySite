import { Component, OnInit } from '@angular/core';
import { DifficultyLevel } from 'src/app/enums/difficulty-level.enum';
import { RecipeService } from 'src/app/services/recipe.service';
import { ActivatedRoute, Router } from '@angular/router';
import { DishService } from 'src/app/services/dish.service';
import { UpdateRecipeModel } from 'src/app/viewmodels/recipe/update-recipe-model.class';
import { IRecipeDetailModel } from 'src/app/interfaces/recipe/recipe-detail-model.interface';
import { DishListModel } from 'src/app/viewmodels/dish/dish-list-model.class';
import { IDishListModel } from 'src/app/interfaces/dish/dish-list-model.interface';
import {
  FormBuilder,
  FormControl,
  FormGroup,
  Validators,
} from '@angular/forms';
import { IRecipeIngredientModel } from 'src/app/interfaces/recipe-ingredient/recipe-ingredient-model.interface';
import { FormArray } from '@angular/forms';
import { CreateRecipeIngredientModel } from 'src/app/viewmodels/recipe-ingredient/create-recipe-ingredient-model.class';
import { ICreateRecipeIngredientModel } from 'src/app/interfaces/recipe-ingredient/create-recipe-ingredient-model.interface';
import { IngredientService } from 'src/app/services/ingredient.service';
import { IIngredientListModel } from 'src/app/interfaces/ingredient/ingredient-list-model.interface';
import { IngredientListModel } from 'src/app/viewmodels/ingredient/ingredient-list-model.class';
import { AuthorService } from 'src/app/services/author.service';
import { BookService } from 'src/app/services/book.service';
import { AuthorModel } from 'src/app/viewmodels/author/author-model.class';
import { BookModel } from 'src/app/viewmodels/book/book-model.class';
import { IBookModel } from 'src/app/interfaces/book/book-model.interface';
import { IAuthorModel } from 'src/app/interfaces/author/author-model.interface';
import { Unit } from 'src/app/enums/unit.enum';

@Component({
  selector: 'app-recipe-edit',
  templateUrl: './recipe-edit.component.html',
  styleUrls: ['./recipe-edit.component.css'],
})
export class RecipeEditComponent implements OnInit {
  private id: number;
  public updateRecipeModel: UpdateRecipeModel = new UpdateRecipeModel();
  difficultyLevels: DifficultyLevel[] = [
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

  public authors: AuthorModel[] = [];
  public books: BookModel[] = [];

  public myForm: FormGroup;
  public ingredients: IngredientListModel[] = [];

  constructor(
    private recipeService: RecipeService,
    private dishService: DishService,
    private router: Router,
    activeRoute: ActivatedRoute,
    private formBuilder: FormBuilder,
    private ingredientService: IngredientService,
    private authorService: AuthorService,
    private bookService: BookService
  ) {
    this.id = Number.parseInt(activeRoute.snapshot.params['id']);
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
    this.updateRecipeModel.recipeIngredients = [
      new CreateRecipeIngredientModel(),
    ];
  }

  public ngOnInit(): void {
    if (this.id) {
      this.recipeService
        .getRecipe(this.id, true)
        .subscribe(
          (data: IRecipeDetailModel) =>
            (this.updateRecipeModel = new UpdateRecipeModel(data))
        );
    }
    this.getDishList();

    this.getIngredientList();
    this.getAuthorList();
    this.getBookList();

    this.myForm.patchValue({
      recipeIngredients: this.updateRecipeModel.recipeIngredients,
    });

    this.myForm.setControl(
      'recipeIngredients',
      this.setExistingBooks(this.updateRecipeModel.recipeIngredients)
    );
  }

  /*  editEmployee(author: IAuthorDetailModel) {
    this.myForm.patchValue({
      books: author.books,
    });

    this.myForm.setControl('skills', this.setExistingBooks(author.books));
  }*/

  setExistingBooks(
    recipeIngredients: ICreateRecipeIngredientModel[]
  ): FormArray {
    const formArray = new FormArray([]);
    recipeIngredients.forEach((s) => {
      formArray.push(
        this.formBuilder.group({
          ingredientId: s.ingredientId,
          unit: s.unit,
          quantity: s.quantity,
        })
      );
    });
    return formArray;
  }

  public updateRecipe(): void {
    this.recipeService
      .updateRecipe(this.updateRecipeModel)
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

  public getFormsControls(): FormArray {
    return this.myForm.controls['recipeIngredients'] as FormArray;
  }

  public addRecipeIngredient(): void {
    (<FormArray>this.myForm.controls['recipeIngredients']).push(
      this.createNewRecipeIngredient()
    );

    this.updateRecipeModel.recipeIngredients.push(
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
}
