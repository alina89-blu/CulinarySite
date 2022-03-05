import { Component, OnInit } from '@angular/core';
import { DishService } from 'src/app/services/dish.service';
import { ActivatedRoute, Router } from '@angular/router';
import { DishCategory } from 'src/app/enums/dish-category.enum';
import { UpdateDishModel } from 'src/app/viewmodels/dish/update-dish-model.class';
import { IDishDetailModel } from 'src/app/interfaces/dish/dish-detail-model.interface';

@Component({
  selector: 'app-dish-edit',
  templateUrl: './dish-edit.component.html',
  styleUrls: ['./dish-edit.component.css'],
})
export class DishEditComponent implements OnInit {
  private id: number;
  public updateDishModel: UpdateDishModel = new UpdateDishModel();
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

  constructor(
    private dishService: DishService,
    private router: Router,
    activeRoute: ActivatedRoute
  ) {
    this.id = Number.parseInt(activeRoute.snapshot.params['id']);
  }

  public ngOnInit(): void {
    if (this.id) {
      this.dishService
        .getDish(this.id, false)
        .subscribe(
          (data: IDishDetailModel) =>
            (this.updateDishModel = new UpdateDishModel(data))
        );
    }
  }

  public updateDish(): void {
    this.dishService
      .updateDish(this.updateDishModel)
      .subscribe(() => this.router.navigateByUrl('dish'));
  }
}
