import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { RecipeService } from 'src/app/services/recipe.service';
import { DifficultyLevel } from 'src/app/enums/difficulty-level.enum';
import { DishService } from 'src/app/services/dish.service';
import { CreateRecipeModel } from 'src/app/viewmodels/recipe/create-recipe-model.class';
import { CreateIngredientModel } from 'src/app/viewmodels/ingredient/create-ingredient-model.class';
import { Unit } from 'src/app/enums/unit.enum';
import { AuthorService } from 'src/app/services/author.service';
import { FormArray, FormControl, FormGroup, Validators } from '@angular/forms';
import { BookService } from 'src/app/services/book.service';
import { IBookModel } from 'src/app/interfaces/book/book-model.interface';
import { BookModel } from 'src/app/viewmodels/book/book-model.class';
import { AfterViewChecked, ChangeDetectorRef } from '@angular/core';
import { AuthorListModel } from 'src/app/viewmodels/author/author-list-model.class';
import { IAuthorListModel } from 'src/app/interfaces/author/author-list-model.interface';
import { CreateOrganicMatterModel } from 'src/app/viewmodels/organic-matter/create-organic-matter-model.class';
import { OrganicMatterName } from 'src/app/enums/organic-matter-name.enum';
import { DishModel } from 'src/app/viewmodels/dish/dish-model.class';
import { IDishModel } from 'src/app/interfaces/dish/dish-model.interface';

@Component({
  selector: 'app-recipe-create',
  templateUrl: './recipe-create.component.html',
  styleUrls: ['./recipe-create.component.css'],
})
export class RecipeCreateComponent implements OnInit, AfterViewChecked {
  public createRecipeModel: CreateRecipeModel = new CreateRecipeModel();
  public dishes: DishModel[] = [];
  public authors: AuthorListModel[] = [];
  public books: BookModel[] = [];

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

  public organicMatters: OrganicMatterName[] = [
    OrganicMatterName.Calories,
    OrganicMatterName.Carbohydrates,
    OrganicMatterName.Grease,
    OrganicMatterName.Protein,
    OrganicMatterName.Sugar,
  ];
  public myForm: FormGroup;
  constructor(
    private recipeService: RecipeService,
    private dishService: DishService,
    private authorService: AuthorService,
    private bookService: BookService,
    private router: Router,
    private readonly changeDetectorRef: ChangeDetectorRef
  ) {
    this.myForm = new FormGroup({
      name: new FormControl('recipe1', [
        Validators.required,
        Validators.minLength(5),
      ]),

      servingsNumber: new FormControl('', [
        Validators.required,
        Validators.min(3),
        //this.servingNumberValidator,
      ]),
      imageUrl: new FormControl('', Validators.required),
      cookingTime: new FormControl('', Validators.required),
      difficultyLevel: new FormControl('Лёгкий', Validators.required),
      content: new FormControl('', Validators.required),
      authorId: new FormControl('', Validators.required),
      bookId: new FormControl('', Validators.required),
      dishId: new FormControl('', Validators.required),

      ingredients: new FormArray([
        new FormGroup({
          name: new FormControl('', Validators.required),
          unit: new FormControl('', Validators.required),
          quantity: new FormControl('', Validators.required),
        }),
      ]),
      organicMatters: new FormArray([
        new FormGroup({
          name: new FormControl('', Validators.required),
          unit: new FormControl('', Validators.required),
          quantity: new FormControl('', Validators.required),
        }),
      ]),
    });
    this.createRecipeModel.ingredients = [new CreateIngredientModel()];
    this.createRecipeModel.organicMatters = [new CreateOrganicMatterModel()];
  }

  public getIngredientsFormsControls(): FormArray {
    return this.myForm.controls['ingredients'] as FormArray;
  }

  public getOrganicMattersFormsControls(): FormArray {
    return this.myForm.controls['organicMatters'] as FormArray;
  }

  public addIngredient(): void {
    (<FormArray>this.myForm.controls['ingredients']).push(
      this.createNewIngredient()
    );

    this.createRecipeModel.ingredients.push(new CreateIngredientModel());
  }

  public addOrganicMatter(): void {
    (<FormArray>this.myForm.controls['organicMatters']).push(
      this.createNewOrganicMatter()
    );

    this.createRecipeModel.organicMatters.push(new CreateOrganicMatterModel());
  }

  public createNewIngredient(): FormGroup {
    const group = new FormGroup({
      name: new FormControl('', Validators.required),
      unit: new FormControl('', Validators.required),
      quantity: new FormControl('', Validators.required),
    });
    return group;
  }

  public createNewOrganicMatter(): FormGroup {
    const group = new FormGroup({
      name: new FormControl('', Validators.required),
      unit: new FormControl('', Validators.required),
      quantity: new FormControl('', Validators.required),
    });
    return group;
  }

  public ngOnInit(): void {
    this.getDishList();
    this.getAuthorList();
    this.getBookList();
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
      .getDishList()
      .subscribe(
        (data: IDishModel[]) =>
          (this.dishes = data.map((x) => new DishModel(x)))
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

  public deleteIngredient(index: number) {
    this.getIngredientsFormsControls().removeAt(index);
  }

  public deleteOrganicMatter(index: number) {
    this.getOrganicMattersFormsControls().removeAt(index);
  }

  public submit() {
    console.log(this.myForm);
    // this.createRecipe();
  }

  get servingsNumber() {
    return this.myForm.get('servingsNumber');
  }

  servingNumberValidator(
    control: FormControl
  ): { [s: string]: boolean } | null {
    if (control.value < 10) {
      return { servingsNumber: true };
    }
    return null;
  }
}
