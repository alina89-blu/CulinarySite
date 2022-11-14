import { Component, OnInit } from '@angular/core';
import { PageEvent } from '@angular/material/paginator';
import { Sort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { ICookingStageListModel } from 'src/app/interfaces/cooking-stage/cooking-stage-list-model.interface';
import { CookingStageService } from 'src/app/services/cooking-stage.service';
import { CookingStageListModel } from 'src/app/viewmodels/cooking-stage/cooking-stage-list-model.class';

@Component({
  selector: 'app-cooking-stage-list',
  templateUrl: './cooking-stage-list.component.html',
  styleUrls: ['./cooking-stage-list.component.css'],
})
export class CookingStageListComponent implements OnInit {
  public totalRows: number = 0;
  public pageSize: number = 5;
  public activeColumn: string;
  public filterValue: string;
  public isAscending: boolean = true;
  public currentPage: number = 1;
  public pageSizeOptions: number[] = [3, 5, 10, 25];

  dataSource: ICookingStageListModel[];
  displayedColumns: string[] = ['id', 'content', 'recipeName', 'actions'];

  constructor(private cookingStageService: CookingStageService) {}

  public ngOnInit(): void {
    this.loadCookingStages();
  }

  public loadCookingStages() {
    this.cookingStageService
      .getPagedCookingStages(
        this.currentPage,
        this.pageSize,
        this.isAscending,
        this.activeColumn,
        this.filterValue
      )
      .subscribe((result) => {
        this.dataSource = result.items;
        this.totalRows = result.totalCount;
      });
  }

  public pageChanged(event: PageEvent) {
    this.pageSize = event.pageSize;
    this.currentPage = event.pageIndex + 1;

    this.loadCookingStages();
  }

  public deleteCookingStage(id: number) {
    this.cookingStageService.deleteCookingStage(id).subscribe(() => {
      this.currentPage = 1;

      this.loadCookingStages();
    });
  }

  public filterData(): void {
    this.currentPage = 1;

    this.loadCookingStages();
  }

  public sortData(sort: Sort) {
    this.isAscending = sort.direction === 'asc';
    this.activeColumn = sort.active;

    this.loadCookingStages();
  }
}
