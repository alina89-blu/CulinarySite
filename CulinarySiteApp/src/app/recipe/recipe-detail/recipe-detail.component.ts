import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { IRecipeDetailModel } from 'src/app/interfaces/recipe/recipe-detail-model.interface';
import { RecipeService } from 'src/app/services/recipe.service';
import { RecipeDetailModel } from 'src/app/viewmodels/recipe/recipe-detail-model.class';

@Component({
  selector: 'app-recipe-detail',
  templateUrl: './recipe-detail.component.html',
  styleUrls: ['./recipe-detail.component.css'],
})
export class RecipeDetailComponent implements OnInit {
  id: number;
  recipeDetailModel: RecipeDetailModel = new RecipeDetailModel();

  constructor(
    private recipeService: RecipeService,
    activeRoute: ActivatedRoute,
    private http: HttpClient
  ) {
    this.id = Number.parseInt(activeRoute.snapshot.params['id']);
  }

  public ngOnInit(): void {
    if (this.id) {
      this.recipeService
        .getRecipe(this.id, true)
        .subscribe(
          (data: IRecipeDetailModel) =>
            (this.recipeDetailModel = new RecipeDetailModel(data))
        );
    }
  }
}
