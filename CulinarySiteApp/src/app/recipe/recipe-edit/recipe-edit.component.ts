import { Component, OnInit } from '@angular/core';
import { DifficultyLevel } from 'src/app/enums/difficulty-level.enum';
import { RecipeService } from 'src/app/services/recipe.service';
import { ActivatedRoute, Router } from '@angular/router';
import { DishService } from 'src/app/services/dish.service';
import { UpdateRecipeModel } from 'src/app/viewmodels/recipe/update-recipe-model.class';
import { IRecipeDetailModel } from 'src/app/interfaces/recipe/recipe-detail-model.interface';
import { DishListModel } from 'src/app/viewmodels/dish/dish-list-model.class';
import { IDishListModel } from 'src/app/interfaces/dish/dish-list-model.interface';
import { AfterViewChecked, ChangeDetectorRef } from '@angular/core';
import {
  FormBuilder,
  FormControl,
  FormGroup,
  Validators,
} from '@angular/forms';

import { FormArray } from '@angular/forms';

import { IngredientService } from 'src/app/services/ingredient.service';
import { IIngredientListModel } from 'src/app/interfaces/ingredient/ingredient-list-model.interface';
import { IngredientListModel } from 'src/app/viewmodels/ingredient/ingredient-list-model.class';
import { AuthorService } from 'src/app/services/author.service';
import { BookService } from 'src/app/services/book.service';
import { BookModel } from 'src/app/viewmodels/book/book-model.class';
import { IBookModel } from 'src/app/interfaces/book/book-model.interface';
import { Unit } from 'src/app/enums/unit.enum';
import { CreateIngredientModel } from 'src/app/viewmodels/ingredient/create-ingredient-model.class';
import { ICreateIngredientModel } from 'src/app/interfaces/ingredient/create-ingredient-model.interface';
import { AuthorListModel } from 'src/app/viewmodels/author/author-list-model.class';
import { IAuthorListModel } from 'src/app/interfaces/author/author-list-model.interface';
import { DishModel } from 'src/app/viewmodels/dish/dish-model.class';
import { IDishModel } from 'src/app/interfaces/dish/dish-model.interface';

@Component({
  selector: 'app-recipe-edit',
  templateUrl: './recipe-edit.component.html',
  styleUrls: ['./recipe-edit.component.css'],
})
export class RecipeEditComponent implements OnInit, AfterViewChecked {
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
  public dishes: DishModel[] = [];

  public authors: AuthorListModel[] = [];
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
    private bookService: BookService,
    private readonly changeDetectorRef: ChangeDetectorRef
  ) {
    this.id = Number.parseInt(activeRoute.snapshot.params['id']);
    this.myForm = new FormGroup({
      name: new FormControl('', [Validators.required, Validators.minLength(5)]),

      servingsNumber: new FormControl('', [
        Validators.required,
        Validators.min(3),
      ]),
      imageUrl: new FormControl('', Validators.required),
      cookingTime: new FormControl('', Validators.required),
      difficultyLevel: new FormControl('', Validators.required),
      content: new FormControl('', Validators.required),
      authorId: new FormControl('', Validators.required),
      bookId: new FormControl('', Validators.required),
      dishId: new FormControl('', Validators.required),
      /*ingredients: new FormArray([
        new FormGroup({
          name: new FormControl('', Validators.required),
          unit: new FormControl('', Validators.required),
          quantity: new FormControl('', Validators.required),
        }),
      ]),*/
    });
    //   this.updateRecipeModel.ingredients = [new CreateIngredientModel()];
  }

  public ngAfterViewChecked(): void {
    this.changeDetectorRef.detectChanges();
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

    /*  this.myForm.patchValue({
      ingredients: this.updateRecipeModel.ingredients,
    });

    this.myForm.setControl(
      'ingredients',
      this.setExistingBooks(this.updateRecipeModel.ingredients)
    );*/
  }

  setExistingBooks(ingredients: ICreateIngredientModel[]): FormArray {
    const formArray = new FormArray([]);
    ingredients.forEach((s) => {
      formArray.push(
        this.formBuilder.group({
          name: s.name,
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
      .getDishList()
      .subscribe(
        (data: IDishModel[]) =>
          (this.dishes = data.map((x) => new DishModel(x)))
      );
  }

  public getIngredientsFormsControls(): FormArray {
    return this.myForm.controls['ingredients'] as FormArray;
  }

  public addIngredient(): void {
    (<FormArray>this.myForm.controls['ingredients']).push(
      this.createNewIngredient()
    );

    this.updateRecipeModel.ingredients.push(new CreateIngredientModel());
  }

  public createNewIngredient(): FormGroup {
    const group = new FormGroup({
      name: new FormControl('', Validators.required),
      unit: new FormControl('', Validators.required),
      quantity: new FormControl('', Validators.required),
    });
    return group;
  }

  public getIngredientList(): void {
    this.ingredientService
      .getIngredientList()
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
        (data: IAuthorListModel[]) =>
          (this.authors = data.map((x) => new AuthorListModel(x)))
      );
  }
}
