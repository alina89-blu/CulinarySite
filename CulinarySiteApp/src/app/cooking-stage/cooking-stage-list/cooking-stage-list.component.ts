import { Component, OnInit } from '@angular/core';
import { ICookingStageListModel } from 'src/app/interfaces/cooking-stage/cooking-stage-list-model.interface';
import { CookingStageService } from 'src/app/services/cooking-stage.service';
import { CookingStageListModel } from 'src/app/viewmodels/cooking-stage/cooking-stage-list-model.class';

@Component({
  selector: 'app-cooking-stage-list',
  templateUrl: './cooking-stage-list.component.html',
  styleUrls: ['./cooking-stage-list.component.css'],
})
export class CookingStageListComponent implements OnInit {
  public cookingStages: CookingStageListModel[] = [];

  constructor(private cookingStageService: CookingStageService) {}

  public ngOnInit(): void {
    this.getCookingStageList();
  }

  public getCookingStageList(): void {
    this.cookingStageService
      .getCookingStageList(true)
      .subscribe(
        (data: ICookingStageListModel[]) =>
          (this.cookingStages = data.map((x) => new CookingStageListModel(x)))
      );
  }

  public deleteCookingStage(id: number) {
    this.cookingStageService
      .deleteCookingStage(id)
      .subscribe(() => this.getCookingStageList());
  }
}
