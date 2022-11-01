import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { DishService } from 'src/app/services/dish.service';
import { DishCategory } from 'src/app/enums/dish-category.enum';
import { CreateDishModel } from 'src/app/viewmodels/dish/create-dish-model.class';
import { FormControl, Validators } from '@angular/forms';

@Component({
  selector: 'app-dish-create',
  templateUrl: './dish-create.component.html',
  styleUrls: ['./dish-create.component.css'],
})
export class DishCreateComponent {
  public createDishModel: CreateDishModel = new CreateDishModel();
  category = new FormControl('', Validators.required);
  imageUrl = new FormControl('', Validators.required);

  public dishCategories: DishCategory[] = [
    DishCategory.Блины,
    DishCategory.ВторыеБлюда,
    DishCategory.Десерты,
    DishCategory.Закуски,
    DishCategory.Напитки,
    DishCategory.Пироги,
    DishCategory.Пицца,
    DishCategory.Салаты,
    DishCategory.СоусыИПриправы,
    DishCategory.Супы,
    DishCategory.ТортыИПирожные,
  ];
  constructor(private dishService: DishService, private router: Router) {}

  public createDish(): void {
    this.dishService
      .createDish(this.createDishModel)
      .subscribe(() => this.router.navigateByUrl('dish'));
  }
}
