import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { CookingStageService } from 'src/app/services/cooking-stage.service';
import { RecipeService } from 'src/app/services/recipe.service';
import { ICookingStageDetailModel } from 'src/app/interfaces/cooking-stage/cooking-stage-detail-model.interface';
import { UpdateCookingStageModel } from 'src/app/viewmodels/cooking-stage/update-cooking-stage-model.class';
import { IRecipeModel } from 'src/app/interfaces/recipe/recipe-model.interface';
import { RecipeModel } from 'src/app/viewmodels/recipe/recipe-model.class';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-cooking-stage-edit',
  templateUrl: './cooking-stage-edit.component.html',
  styleUrls: ['./cooking-stage-edit.component.css'],
})
export class CookingStageEditComponent implements OnInit {
  private id: number;
  public updateCookingStageModel: UpdateCookingStageModel =
    new UpdateCookingStageModel();
  recipes: RecipeModel[] = [];
  public cookingStageForm: FormGroup;

  constructor(
    private cookingStageService: CookingStageService,
    private recipeService: RecipeService,
    private router: Router,
    activeRoute: ActivatedRoute,
    private fb: FormBuilder
  ) {
    this.id = Number.parseInt(activeRoute.snapshot.params['id']);
    this.cookingStageForm = this.fb.group({
      content: ['', Validators.required],
      imageUrl: [''],
      recipeId: ['', Validators.required],
    });
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

  public getRecipeList() {
    this.recipeService
      .getRecipeList()
      .subscribe(
        (data: IRecipeModel[]) =>
          (this.recipes = data.map((x) => new RecipeModel(x)))
      );
  }

  public updateCookingStage(): void {
    this.cookingStageService
      .updateCookingStage(this.updateCookingStageModel)
      .subscribe(() => this.router.navigateByUrl('cookingStage'));
  }
}
