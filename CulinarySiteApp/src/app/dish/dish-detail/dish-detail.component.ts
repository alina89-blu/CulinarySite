import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { IDishDetailModel } from 'src/app/interfaces/dish/dish-detail-model.interface';
import { DishService } from 'src/app/services/dish.service';
import { DishDetailModel } from 'src/app/viewmodels/dish/dish-detail-model.class';

@Component({
  selector: 'app-dish-detail',
  templateUrl: './dish-detail.component.html',
  styleUrls: ['./dish-detail.component.css'],
})
export class DishDetailComponent implements OnInit {
  private id: number;
  public dishDetailModel: DishDetailModel = new DishDetailModel();

  constructor(
    private readonly dishService: DishService,
    activeRoute: ActivatedRoute
  ) {
    this.id = Number.parseInt(activeRoute.snapshot.params['id']);
  }

  public ngOnInit(): void {
    if (this.id) {
      this.dishService
        .getDish(this.id, true)
        .subscribe(
          (data: IDishDetailModel) =>
            (this.dishDetailModel = new DishDetailModel(data))
        );
    }
  }
}
