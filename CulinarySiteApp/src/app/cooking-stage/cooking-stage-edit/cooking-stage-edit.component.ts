import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { CookingStageService } from 'src/app/services/cooking-stage.service';
import { RecipeService } from 'src/app/services/recipe.service';
import { ICookingStageDetailModel } from 'src/app/interfaces/cooking-stage/cooking-stage-detail-model.interface';
import { UpdateCookingStageModel } from 'src/app/viewmodels/cooking-stage/update-cooking-stage-model.class';
import { RecipeListModel } from 'src/app/viewmodels/recipe/recipe-list-model.class';
import { IRecipeListModel } from 'src/app/interfaces/recipe/recipe-list-model.interface';

@Component({
  selector: 'app-cooking-stage-edit',
  templateUrl: './cooking-stage-edit.component.html',
  styleUrls: ['./cooking-stage-edit.component.css'],
})
export class CookingStageEditComponent implements OnInit {
  private id: number;
  public updateCookingStageModel: UpdateCookingStageModel =
    new UpdateCookingStageModel();
  recipes: RecipeListModel[] = [];

  constructor(
    private cookingStageService: CookingStageService,
    private recipeService: RecipeService,
    private router: Router,
    activeRoute: ActivatedRoute
  ) {
    this.id = Number.parseInt(activeRoute.snapshot.params['id']);
  }

  public ngOnInit(): void {
    if (this.id) {
      this.cookingStageService
        .getCookingStage(this.id, true)
        .subscribe(
          (data: ICookingStageDetailModel) =>
            (this.updateCookingStageModel = new UpdateCookingStageModel(data))
        );
    }
    this.getRecipeList();
  }

  public updateCookingStage(): void {
    this.cookingStageService
      .updateCookingStage(this.updateCookingStageModel)
      .subscribe(() => this.router.navigateByUrl('cookingStage'));
  }

  public getRecipeList() {
    this.recipeService
      .getRecipeList(false)
      .subscribe(
        (data: IRecipeListModel[]) =>
          (this.recipes = data.map((x) => new RecipeListModel(x)))
      );
  }
}
