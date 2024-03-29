import { Component, OnInit } from '@angular/core';
import { DishService } from 'src/app/services/dish.service';
import { DishListModel } from 'src/app/viewmodels/dish/dish-list-model.class';
import { IDishListModel } from 'src/app/interfaces/dish/dish-list-model.interface';
import { MatTableDataSource } from '@angular/material/table';

@Component({
  selector: 'app-dish-list',
  templateUrl: './dish-list.component.html',
  styleUrls: ['./dish-list.component.css'],
})
export class DishListComponent implements OnInit {
  public dishes: DishListModel[] = [];
  public displayedColumns: string[] = ['id', 'category', 'image', 'actions'];
  public dataSource: MatTableDataSource<IDishListModel>;

  constructor(private readonly dishService: DishService) {}

  public ngOnInit(): void {
    this.getDishDetailList();
  }

  public getDishDetailList(): void {
    this.dishService
      .getDishDetailList(true)
      .subscribe((data: IDishListModel[]) => {
        this.dishes = data.map((x) => new DishListModel(x));
        this.dataSource = new MatTableDataSource<IDishListModel>(this.dishes);
      });
  }

  public deleteDish(id: number): void {
    this.dishService.deleteDish(id).subscribe(() => this.getDishDetailList());
  }
}
